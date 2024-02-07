using System.Diagnostics;
using System.Globalization;

Console.Write("Input file path:");
var inputPath = Console.ReadLine();

if (!File.Exists(inputPath)) {
    Console.WriteLine("File not found.");
    return;
}

var lines = File.ReadAllLines(inputPath).Select(e => e.Trim()).Where(e => !string.IsNullOrWhiteSpace(e)).ToArray();
var isNumericList = Array.TrueForAll(lines, e => int.TryParse(e, out _));
var stopwatch = new Stopwatch();

var intList = new List<int> {
    Capacity = lines.Length
};
var stringList = new List<string> {
    Capacity = lines.Length
};

Console.Write("Choose sorting algorithm (1 for Bubble Sort, 2 for Quick Sort, 3 for Bogo Sort): ");

if (isNumericList) {
    intList = [..Array.ConvertAll(lines, int.Parse)];
    var sortAlgorithm = Console.ReadLine();

    switch (sortAlgorithm) {
        case "1":
            stopwatch.Start();
            BubbleSort(intList);
            break;
        case "2":
            stopwatch.Start();
            QuickSort(intList, 0, intList.Count - 1);
            break;
        case "3":
            stopwatch.Start();
            BogoSort(intList);
            break;
        default:
            Console.WriteLine("Invalid choice.");
            return;
    }

    stopwatch.Stop();
} else {
    stringList = [..lines];
    var sortAlgorithm = Console.ReadLine();

    switch (sortAlgorithm) {
        case "1":
            stopwatch.Start();
            BubbleSort(stringList);
            break;
        case "2":
            stopwatch.Start();
            QuickSort(stringList, 0, stringList.Count - 1);
            break;
        case "3":
            stopwatch.Start();
            BogoSort(stringList);
            break;
        default:
            Console.WriteLine("Invalid sorting algorithm choice.");
            return;
    }

    stopwatch.Stop();
}

if (isNumericList) {
    intList.ForEach(Console.WriteLine);
} else {
    stringList.ForEach(Console.WriteLine);
}

Console.WriteLine($"Sorted {lines.Length} elements in {stopwatch.Elapsed.TotalMicroseconds.ToString(CultureInfo.InvariantCulture).Replace(',', '.')}μs");
return;

static void BubbleSort<T>(IList<T> arr) where T : IComparable<T> {
    var n = arr.Count;
    
    for (var i = 0; i < n - 1; i++) {
        for (var j = 0; j < n - i - 1; j++) {
            if (arr[j].CompareTo(arr[j + 1]) > 0) {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
            }
        }
    }
}

static void QuickSort<T>(IList<T> arr, int low, int high) where T : IComparable<T> {
    while (true) {
        if (low < high) {
            var pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);

            low = pi + 1;
            
            continue;
        }

        break;
    }
}

static int Partition<T>(IList<T> arr, int low, int high) where T : IComparable<T> {
    var pivot = arr[high];
    var i = low - 1;

    for (var j = low; j < high; j++) {
        if (arr[j].CompareTo(pivot) >= 0) continue;
        i++;
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);

    return i + 1;
}

static bool IsSorted<T>(IReadOnlyList<T> data) where T : IComparable<T> {
    var count = data.Count;

    while (--count >= 1) {
        if (data[count].CompareTo(data[count - 1]) < 0) {
            return false;
        }
    }
    
    return true;
}

static void Shuffle<T>(IList<T> data) {
    var rand = new Random();

    for (var i = 0; i < data.Count; ++i) {
        var rnd = rand.Next(data.Count);
        (data[i], data[rnd]) = (data[rnd], data[i]);
    }
}

static void BogoSort<T>(List<T> arr) where T : IComparable<T> {
    while (!IsSorted(arr)) Shuffle(arr);
}
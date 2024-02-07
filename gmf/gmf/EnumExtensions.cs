namespace gmf;

public static class EnumExtensions {
    public static T GetRandomEnumValue<T>(T t) where T : Enum {
        return Enum.GetValues(t)
            .OfType<Enum>()
            .OrderBy(e => Guid.NewGuid())
            .FirstOrDefault();
    }
}
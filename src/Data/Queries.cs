﻿namespace Data;

public static class Queries
{
    public static string SqlFileExtension = ".sql";

    public static string SqlFolder = "Sql";

    public static string AdhocFolder = "Adhoc";

    #region Queries

    public static string CreateListQuery = nameof(CreateListQuery);

    public static string UpdateListQuery = nameof(UpdateListQuery);

    public static string DeleteListQuery = nameof(DeleteListQuery);

    public static string CreateTaskQuery = nameof(CreateTaskQuery);

    public static string UpdateTaskQuery = nameof(UpdateTaskQuery);

    public static string UpdateTaskStatusQuery = nameof(UpdateTaskStatusQuery);

    public static string UpdateUserTimeZoneQuery = nameof(UpdateUserTimeZoneQuery);

    public static string DeleteTaskQuery = nameof(DeleteTaskQuery);

    public static string CreateProfileQuery = nameof(CreateProfileQuery);

    public static string GetListsByProfileIdQuery = nameof(GetListsByProfileIdQuery);

    public static string GetProfileByUserNameQuery = nameof(GetProfileByUserNameQuery);

    #endregion Queries
}

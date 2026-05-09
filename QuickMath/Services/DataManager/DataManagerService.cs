using System.Text.Json;

namespace QuickMath.Services.DataManager
{

    public static class DataManagerService
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

    }
}

using System.Text.Json;

namespace QuickMath.Services.DataManager
{
    public static class DataManagerService
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        public static UserDataModel LoadOrCreate(string filePath)
        {
            if (!File.Exists(filePath))
                return UserDataModel.CreateDefault("Player");

            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<UserDataModel>(json);
                return data ?? UserDataModel.CreateDefault("Player");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Failed to load user data");
                UserDataModel fallback = UserDataModel.CreateDefault("Player");
                Save(fallback, filePath);
                return fallback;
            }
        }

        public static void Save(UserDataModel data, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, JsonOptions);
                File.WriteAllText(filePath, json);
                AppLogger.Info($"Data saved — XP={data.XP} coins={data.coins}");
            }
            catch (Exception ex)
            {
                AppLogger.Error(ex, "Failed to save user data");
            }
        }
    }
}

namespace ControlDesktopDomainModel.Service.ApiProvider
{
    public static class URIWrapper
    {
        public static readonly string URL = @"https://pfhil.ru";
        public static readonly string Controller = "control_computer";

        public static string Register() =>
            $@"{URL}/{Controller}/register";

        public static string ChangeRegisterData() =>
            $@"{URL}/{Controller}/change_register_data";

        public static string GetCommand() =>
            $@"{URL}/{Controller}/get_command";

        public static string SendReport() =>
            $@"{URL}/{Controller}/send_report";

        public static string SendFile() =>
            $@"{URL}/{Controller}/send_file";
    }
}
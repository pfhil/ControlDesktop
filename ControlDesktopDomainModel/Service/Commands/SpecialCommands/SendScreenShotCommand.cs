using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ControlDesktopDomainModel.Service.ApiProvider;
using ControlDesktopDomainModel.Service.Configuration;

namespace ControlDesktopDomainModel.Service.Commands.SpecialCommands
{
    public class SendScreenShotCommand : Command
    {
        public override string Name { get; } = "SendScreenShot";
        public override void Execute(dynamic instruction)
        {
            string fileName = Path.GetRandomFileName()+".jpg";
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                bitmap.Save(fileName, ImageFormat.Jpeg);
            }


            var st = ApiMediator.SendFile(ConfigurationManager.AppLogin, ConfigurationManager.AppPassword, fileName).Result;
            File.Delete(fileName);

            var report = new Dictionary<string, dynamic>
            {
                {"command_state", "ok_send"},
                {"file_name", fileName}
            };
            this.Report(report);
        }
    }
}
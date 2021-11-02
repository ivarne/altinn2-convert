using System;
using System.IO;
using System.Threading.Tasks;
using Altinn2Convert.Services;

namespace Altinn2Convert
{
    /// <summary>
    /// Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static async Task Main()
        {
            // var mode = "generate";
            var mode = "test";
            // var mode = "run";
            if (mode == "generate")
            {
                var generateClass = new GenerateAltinn3ClassesFromJsonSchema();
                await generateClass.Generate();
            }
            
            if (mode == "test")
            {
                var service = new ConvertService();
                var a2 = await service.ParseAltinn2File("TULPACKAGE.zip");
                await service.DumpAltinn2Data(a2, Path.Join("out", "altinn2.json"));
                var a3 = await service.Convert(a2);
                await service.WriteAltinn3Files(a3, "out");
            }

            if (mode == "run")
            {
                var homeFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
                var tulFolder = Path.Join(homeFolder, "TUL");
                var altinn3Folder = Path.Join(homeFolder, "TULtoAltinn3");

                var bs = new BatchService();
                await bs.ConvertAll(tulFolder, altinn3Folder);
            }
        }
    }
}

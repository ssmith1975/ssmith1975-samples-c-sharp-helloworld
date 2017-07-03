using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SimplyWriterLib {
    public class SimpleWriterFile : SimpleWriterStreamBase {
        public string FileName { get; set; }

        public SimpleWriterFile() {

            // Create file in current directory the application is running in
            FileName =  Path.GetFullPath(@".\SimpleWriterFileOutput.txt");
            Stream = createFileStream();
            Console.WriteLine("Output file to current directory {0}", FileName);
        }

        public SimpleWriterFile(string fileName) {

            FileName = fileName;
            Stream = createFileStream();
            Console.WriteLine("Output file to selected directory {0}", FileName);
        }

        private Stream createFileStream() {
            FileStream fileStream;

            // Setup target directory
            string filePathDirectory = Path.GetDirectoryName(FileName);

            if (!Directory.Exists(filePathDirectory)) {

                if (HasWriteAccessToFile(FileName)) {
                    Directory.CreateDirectory(filePathDirectory);
                } else {
                    string errorMsg;

                    errorMsg = String.Format("Not authorized to create file in {0} directory", filePathDirectory);
                    throw new UnauthorizedAccessException(errorMsg);
                }

            }

            // Create FileStream instance
            fileStream = new FileStream(FileName, FileMode.Create);
            return fileStream;
        }

        //}
        // Method borrowed from StackOverflow 
        // (https://stackoverflow.com/questions/130617/how-do-you-check-for-permissions-to-write-to-a-directory-or-file)
        private static bool HasWriteAccessToFile(string filePath) {
            try {
                var permissionSet = new PermissionSet(PermissionState.None);
                var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, filePath);
                permissionSet.AddPermission(writePermission);
                return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
            } catch (Exception ex) {


                return false;
            }
        }

    }
}

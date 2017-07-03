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

        public SimpleWriterFile():this(@".\SimpleWriterFileOutput.txt") {

            // Create file in current directory the string fileName

        }

        public SimpleWriterFile(string fileName) {
            
            // Get full path of file name
            FileName = Path.GetFullPath(fileName);
           
           // Create FileStream instance once
            Stream = createFileStream(); 

            // What to do when SayHello completes
            OnEndSayHello = (bw) => {
                Console.WriteLine("Output file to selected directory {0}", FileName);

                // Close BinaryWriter stream and call Dispose at end of SayHello
                bw.Close();
                base.Dispose();

            };

        }

        private Stream createFileStream() {
            string filePathDirectory;
            FileStream fileStream;
           
            // Setup target directory
           filePathDirectory = Path.GetDirectoryName(FileName);

            // Does target directory exists?
            if (!Directory.Exists(filePathDirectory)) {

                // Setup write permission on file
                if (HasWriteAccessToFile(FileName)) {
                    Directory.CreateDirectory(filePathDirectory);
                } else {
                    string errorMsg;

                    // Setup error
                    errorMsg = String.Format("Not authorized to create file in {0} directory", filePathDirectory);
                    throw new UnauthorizedAccessException(errorMsg);
                }

            }

            // Create FileStream instance
            fileStream = new FileStream(FileName, FileMode.Create);
            //Stream fileStream2 = File.WriteAllBytes();

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

using PowerArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNoteTools.Code
{
    // A class that describes the command line arguments for this program
    public class CmdArgs
    {
        // This argument is required and if not specified the user will
        // be prompted.
        //[ArgRequired(PromptIfMissing = true)]
        public string InputMdPath { get; set; }
        public string Method { get; set; }
        public string github_image_prefix_url { get; set; }
    }
}

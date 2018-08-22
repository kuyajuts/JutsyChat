using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JutsyChat
{
    public class Chatmate
    {
        public string ConnectionID { get; set; }
        public string Handle { get; set; }
        public string ConnectionIP { get; set; }
        public string ChatPicture { get; set; }
        public string ChatboxColor { get; set; }
    }
}
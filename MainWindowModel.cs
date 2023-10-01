using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization_Demo
{
    public record RefreshMessage();
    partial class MainWindowModel : ObservableObject
    {
        public int? ID { get; set; }
        public string? Name { get; set; }
    }
}

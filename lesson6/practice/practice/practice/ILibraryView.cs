using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice {
    internal interface ILibraryView {
        TextBox[] TextBoxes { get; set; }
        Label[] Labels { get; set; }
        Label Output { get; set; }

        event EventHandler<EventArgs> Save;
        event EventHandler<EventArgs> Delete;
    }
}

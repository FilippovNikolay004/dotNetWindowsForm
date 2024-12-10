using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice {
    internal class LibraryPresenter {
        private readonly IModel _model;
        private readonly ILibraryView _view;

        public LibraryPresenter(IModel model, ILibraryView view) {
            _model = model;
            _view = view;

            _view.Save += new EventHandler<EventArgs>(Save);
            _view.Delete += new EventHandler<EventArgs>(Delete);
            _view.DeleteAll += new EventHandler<EventArgs>(DeleteAll);
            _view.GetFirstBook += new EventHandler<EventArgs>(GetFirstBook);

            UpdateView();
        }

        private void Save(object? sender, EventArgs e) {
            if (sender == null) { return; }

            _model.TextBoxes = _view.TextBoxes;
            _model.Labels = _view.Labels;
            _model.SaveToFile();

            UpdateView();
        }
        private void Delete(object? sender, EventArgs e) {
            if (sender == null) { return; }

            _model.TextBoxes = _view.TextBoxes;
            _model.Labels = _view.Labels;
            _model.DeleteFromFile();

            UpdateView();
        }
        private void DeleteAll(object? sender, EventArgs e) {
            if (sender == null) { return; }

            _model.TextBoxes = _view.TextBoxes;
            _model.Labels = _view.Labels;
            _model.DeleteAllFromFile();

            UpdateView();
        }
        private void GetFirstBook(object? sender, EventArgs e) {
            if (sender == null) { return; }

            MessageBox.Show($"{_model.GetFirstBook()}", "Информация");

            UpdateView();
        }

        private void UpdateView() {
            _view.Output.Text = "";

            string[] lines = _model.LoadFromFile();
            for (int i = 0; i < lines.Length; i++) {
                _view.Output.Text += lines[i];
            }
        }
    }
}
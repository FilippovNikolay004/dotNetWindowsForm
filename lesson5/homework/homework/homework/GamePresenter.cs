using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework {
    internal class GamePresenter {
        private readonly IModel _model;
        private readonly IGameView _view;

        public GamePresenter(IModel model, IGameView view) {
            _model = model;
            _view = view;

            _view.Start += new EventHandler<EventArgs>(Start);
            _view.CellClicked += new EventHandler<EventArgs>(CellSelection);

            UpdateView();
        }

        private void Start(object? sender, EventArgs e) {
            if (sender == null) return;

            _model.StartBtn = _view.StartBtn;
            _model.buttons = _view.buttons;
            _model.LevelGroup = _view.LevelGroup;
            _model.WhoFirst = _view.WhoFirst;
            _model.cellStates = _view.cellStates;
            _model.isHardLevel = _view.isHardLevel;
            _model.buttonImageO = _view.buttonImageO;
            _model.buttonImageX = _view.buttonImageX;
            _model.StartGame();

            UpdateView();
        }

        private void CellSelection(object? sender, EventArgs e) {
            if (sender == null) return;
            Button button = (Button)sender;
            
            _model.ChoiceCell(button);
        }


        private void UpdateView() {
            
        }
    }
}

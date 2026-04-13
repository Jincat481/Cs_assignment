using week5_assignment.Models;

var itemModel = new ItemModel();
var gachaModel = new GachaModel();
var view = new week5_assignment.Main.View();

var presenter = new week5_assignment.Main.Presenter(itemModel, gachaModel, view);
presenter.Run();
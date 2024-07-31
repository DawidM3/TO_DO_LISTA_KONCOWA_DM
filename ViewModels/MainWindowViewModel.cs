using ReactiveUI;
using System;
using System.Reactive.Linq;
using ToDoList.DataModel;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ToDoListService _service;
        private ViewModelBase _contentViewModel;

        public MainWindowViewModel()
        {
            _service = new ToDoListService();
            ToDoList = new ToDoListViewModel(_service.GetItems());
            _contentViewModel = ToDoList;

            ToDoList.ListItems.CollectionChanged += (s, e) => _service.SaveItems(ToDoList.ListItems);
        }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public ToDoListViewModel ToDoList { get; }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

            Observable.Merge(
                addItemViewModel.OkCommand,
                addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        ToDoList.ListItems.Add(newItem);
                        _service.SaveItems(ToDoList.ListItems);
                    }
                    ContentViewModel = ToDoList;
                });

            ContentViewModel = addItemViewModel;
        }
    }
}

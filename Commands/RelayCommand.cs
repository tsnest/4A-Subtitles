using System;
using System.Windows.Input;

namespace _4A_Subtitles.Commands
{
  public class RelayCommand : ICommand
  {
    public event EventHandler CanExecuteChanged;

    private Action<object> _Excute { get; set; }

    private Predicate<object> _CanExcute { get; set; }

    public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
    {
      this._Excute = ExcuteMethod;
      this._CanExcute = CanExcuteMethod;
    }

    public bool CanExecute(object parameter) => this._CanExcute(parameter);

    public void Execute(object parameter) => this._Excute(parameter);
  }
}

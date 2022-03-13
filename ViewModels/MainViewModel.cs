using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using WpfApp1.Annotations;
using WpfApp1.Models;
namespace WpfApp1.ViewModels;

public class MainViewModel: INotifyPropertyChanged
{
    private DataTable _data;
    private string _inputpath;

    public DataTable Data
    {
        set
        {
            _data = value;
            this._data = Csv2Datatable.FromCsv(this._inputpath);
            OnPropertyChanged();
        }
    }

    public string InputPath
    {
        get { return this._inputpath; }
        set
        {
            this._inputpath = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
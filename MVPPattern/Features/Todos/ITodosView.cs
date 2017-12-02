//http://valokafor.com/learn-android-mvp-pattern-example/
//View – this defines the methods that the concrete View will implement. 
//This way you can proceed to create and test the Presenter without worrying about Android-specific 
//components such as Context.
public interface ITodosView
{
    void Busy(bool value = false);
    void OnShowTodosButtonClicked();
    void NotifyDataSetChanged();
    void ShowTodoDetail(string value);
}

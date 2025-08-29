namespace Core.Entities.Edits;

public interface IEdit<in T> where T : IEditable {
    
    public void Apply(T editable);

}

public interface IEdit : IEdit<IEditable> {
    
}
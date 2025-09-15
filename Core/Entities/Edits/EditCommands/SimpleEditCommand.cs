namespace Core.Entities.Edits.EditCommands {

    public class SimpleEditCommand<T> : IEditCommand where T : IEditable {

        private readonly IEdit<T> _edit;
        private readonly T _editable;

        public SimpleEditCommand(IEdit<T> edit, T editable) {
            _edit = edit;
            _editable = editable;
        }

        public void Execute() {
            _edit.Apply(_editable);
        }

    }

}

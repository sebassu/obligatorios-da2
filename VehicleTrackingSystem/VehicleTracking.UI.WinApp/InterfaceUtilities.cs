using System;
using System.Windows.Forms;

namespace VehicleTracking.UI.WinApp
{
    public static class InterfaceUtilities
    {
        public static void ExcecuteActionOrThrowErrorMessageBox(Action actionToExecute)
        {
            try
            {
                actionToExecute.Invoke();
            }
            catch (SystemException exception)
            {
                ShowError(exception.Message, "Error");
            }
        }

        public static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AskForDeletionConfirmationAndExecute(Action deletionAction)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar al elemento " +
                "seleccionado? La operación es irreversible.", "Confirmación", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ExcecuteActionOrThrowErrorMessageBox(deletionAction);
            }
        }

        public static void SuccessfulOperation()
        {
            MessageBox.Show("La operación se completó exitosamente.", "Operación exitosa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void HideAllForms()
        {
            foreach (Form oneForm in Application.OpenForms)
            {
                oneForm.Hide();
            }
        }

        public static void NotElementSelectedMessageBox()
        {
            DialogResult result = MessageBox.Show("Debe seleccionar un elemento de la lista.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ChangeUserControl(UserControl someUserControl,
            Panel systemPanel)
        {
            systemPanel.Controls.Clear();
            systemPanel.Controls.Add(someUserControl);
        }

        public static void PerformActionIfElementIsSelected(ListView component, Action actionToPerform)
        {
            if (component.SelectedItems.Count > 0)
            {
                ExcecuteActionOrThrowErrorMessageBox(actionToPerform);
            }
            else
            {
                NotElementSelectedMessageBox();
            }
        }
    }
}
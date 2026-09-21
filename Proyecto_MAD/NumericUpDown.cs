using System;
using System.Windows.Forms;
using System.Drawing;

public class DataGridViewNumericUpDownColumn : DataGridViewColumn
{
    public DataGridViewNumericUpDownColumn() : base(new DataGridViewNumericUpDownCell())
    {
    }
}

public class DataGridViewNumericUpDownCell : DataGridViewTextBoxCell
{
    public DataGridViewNumericUpDownCell() : base()
    {
        this.Style.Format = "N0"; 
    }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;

        if (this.Value == null || this.Value == DBNull.Value)
            ctl.Value = ctl.Minimum;
        else
            ctl.Value = Convert.ToDecimal(this.Value);
    }

    public override Type EditType => typeof(NumericUpDownEditingControl);
    public override Type ValueType => typeof(int);
    public override object DefaultNewRowValue => 1;
}

public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
{
    DataGridView dataGridView;
    private bool valueChanged = false;
    int rowIndex;

    public NumericUpDownEditingControl()
    {
        this.Minimum = 0;
        this.Maximum = 100; 
    }

    public object EditingControlFormattedValue
    {
        get { return this.Value.ToString("N0"); }
        set
        {
            if (value is string)
            {
                if (decimal.TryParse((string)value, out decimal val))
                    this.Value = val;
            }
        }
    }

    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        return EditingControlFormattedValue;
    }

    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.TextAlign = HorizontalAlignment.Right;
    }

    public int EditingControlRowIndex
    {
        get { return rowIndex; }
        set { rowIndex = value; }
    }

    public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
    {
        switch (keyData & Keys.KeyCode)
        {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
                return true;
            default:
                return !dataGridViewWantsInputKey;
        }
    }

    public void PrepareEditingControlForEdit(bool selectAll)
    {
        if (selectAll)
            this.Select(0, this.Text.Length);
        else
            this.Select(this.Text.Length, 0);
    }

    public bool RepositionEditingControlOnValueChange => false;

    public DataGridView EditingControlDataGridView
    {
        get { return dataGridView; }
        set { dataGridView = value; }
    }

    public bool EditingControlValueChanged
    {
        get { return valueChanged; }
        set { valueChanged = value; }
    }

    public Cursor EditingPanelCursor => Cursors.Default;

    protected override void OnValueChanged(EventArgs e)
    {
        valueChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(e);
    }
}

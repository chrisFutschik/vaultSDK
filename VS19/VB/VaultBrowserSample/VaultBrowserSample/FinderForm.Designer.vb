<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.m_openFileToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_findButton = New System.Windows.Forms.Button()
        Me.m_itemsCountLabel = New System.Windows.Forms.Label()
        Me.SearchResultLabel = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.ValueTextBoxLabel = New System.Windows.Forms.Label()
        Me.m_valueTextBox = New System.Windows.Forms.TextBox()
        Me.ConditionComboBoxLabel = New System.Windows.Forms.Label()
        Me.PropertyComboBoxLabel = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.m_searchResultsListBox = New System.Windows.Forms.ListBox()
        Me.m_removeCriteriaButton = New System.Windows.Forms.Button()
        Me.m_addCriteriaButton = New System.Windows.Forms.Button()
        Me.m_criteriaListBox = New System.Windows.Forms.ListBox()
        Me.m_conditionComboBox = New System.Windows.Forms.ComboBox()
        Me.m_propertyComboBox = New System.Windows.Forms.ComboBox()
        Me.contextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_openFileToolStripMenuItem2})
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'm_openFileToolStripMenuItem2
        '
        Me.m_openFileToolStripMenuItem2.Name = "m_openFileToolStripMenuItem2"
        Me.m_openFileToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.m_openFileToolStripMenuItem2.Text = "Open File"
        '
        'm_findButton
        '
        Me.m_findButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_findButton.Location = New System.Drawing.Point(623, 70)
        Me.m_findButton.Name = "m_findButton"
        Me.m_findButton.Size = New System.Drawing.Size(75, 23)
        Me.m_findButton.TabIndex = 29
        Me.m_findButton.Text = "Find Now"
        '
        'm_itemsCountLabel
        '
        Me.m_itemsCountLabel.AutoSize = True
        Me.m_itemsCountLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_itemsCountLabel.Location = New System.Drawing.Point(31, 374)
        Me.m_itemsCountLabel.Name = "m_itemsCountLabel"
        Me.m_itemsCountLabel.Size = New System.Drawing.Size(43, 13)
        Me.m_itemsCountLabel.TabIndex = 28
        Me.m_itemsCountLabel.Text = "0 Items"
        '
        'SearchResultLabel
        '
        Me.SearchResultLabel.AutoSize = True
        Me.SearchResultLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchResultLabel.Location = New System.Drawing.Point(31, 246)
        Me.SearchResultLabel.Name = "SearchResultLabel"
        Me.SearchResultLabel.Size = New System.Drawing.Size(82, 13)
        Me.SearchResultLabel.TabIndex = 27
        Me.SearchResultLabel.Text = "Search Results:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(31, 110)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(170, 13)
        Me.label2.TabIndex = 23
        Me.label2.Text = "Find items that match this criteria:"
        '
        'ValueTextBoxLabel
        '
        Me.ValueTextBoxLabel.AutoSize = True
        Me.ValueTextBoxLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ValueTextBoxLabel.Location = New System.Drawing.Point(327, 46)
        Me.ValueTextBoxLabel.Name = "ValueTextBoxLabel"
        Me.ValueTextBoxLabel.Size = New System.Drawing.Size(37, 13)
        Me.ValueTextBoxLabel.TabIndex = 21
        Me.ValueTextBoxLabel.Text = "Value:"
        '
        'm_valueTextBox
        '
        Me.m_valueTextBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_valueTextBox.Location = New System.Drawing.Point(327, 70)
        Me.m_valueTextBox.Name = "m_valueTextBox"
        Me.m_valueTextBox.Size = New System.Drawing.Size(272, 21)
        Me.m_valueTextBox.TabIndex = 20
        '
        'ConditionComboBoxLabel
        '
        Me.ConditionComboBoxLabel.AutoSize = True
        Me.ConditionComboBoxLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConditionComboBoxLabel.Location = New System.Drawing.Point(199, 46)
        Me.ConditionComboBoxLabel.Name = "ConditionComboBoxLabel"
        Me.ConditionComboBoxLabel.Size = New System.Drawing.Size(56, 13)
        Me.ConditionComboBoxLabel.TabIndex = 19
        Me.ConditionComboBoxLabel.Text = "Condition:"
        '
        'PropertyComboBoxLabel
        '
        Me.PropertyComboBoxLabel.AutoSize = True
        Me.PropertyComboBoxLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PropertyComboBoxLabel.Location = New System.Drawing.Point(31, 46)
        Me.PropertyComboBoxLabel.Name = "PropertyComboBoxLabel"
        Me.PropertyComboBoxLabel.Size = New System.Drawing.Size(53, 13)
        Me.PropertyComboBoxLabel.TabIndex = 16
        Me.PropertyComboBoxLabel.Text = "Property:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Blue
        Me.label1.Location = New System.Drawing.Point(15, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 15
        Me.label1.Text = "Search For:"
        '
        'm_searchResultsListBox
        '
        Me.m_searchResultsListBox.ContextMenuStrip = Me.contextMenuStrip1
        Me.m_searchResultsListBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_searchResultsListBox.Location = New System.Drawing.Point(31, 270)
        Me.m_searchResultsListBox.Name = "m_searchResultsListBox"
        Me.m_searchResultsListBox.Size = New System.Drawing.Size(568, 95)
        Me.m_searchResultsListBox.TabIndex = 26
        '
        'm_removeCriteriaButton
        '
        Me.m_removeCriteriaButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_removeCriteriaButton.Location = New System.Drawing.Point(519, 102)
        Me.m_removeCriteriaButton.Name = "m_removeCriteriaButton"
        Me.m_removeCriteriaButton.Size = New System.Drawing.Size(75, 23)
        Me.m_removeCriteriaButton.TabIndex = 25
        Me.m_removeCriteriaButton.Text = "Remove"
        '
        'm_addCriteriaButton
        '
        Me.m_addCriteriaButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_addCriteriaButton.Location = New System.Drawing.Point(423, 102)
        Me.m_addCriteriaButton.Name = "m_addCriteriaButton"
        Me.m_addCriteriaButton.Size = New System.Drawing.Size(75, 23)
        Me.m_addCriteriaButton.TabIndex = 24
        Me.m_addCriteriaButton.Text = "Add"
        '
        'm_criteriaListBox
        '
        Me.m_criteriaListBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_criteriaListBox.Location = New System.Drawing.Point(31, 134)
        Me.m_criteriaListBox.Name = "m_criteriaListBox"
        Me.m_criteriaListBox.Size = New System.Drawing.Size(568, 95)
        Me.m_criteriaListBox.TabIndex = 22
        '
        'm_conditionComboBox
        '
        Me.m_conditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_conditionComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_conditionComboBox.ItemHeight = 13
        Me.m_conditionComboBox.Location = New System.Drawing.Point(199, 70)
        Me.m_conditionComboBox.Name = "m_conditionComboBox"
        Me.m_conditionComboBox.Size = New System.Drawing.Size(112, 21)
        Me.m_conditionComboBox.TabIndex = 18
        '
        'm_propertyComboBox
        '
        Me.m_propertyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.m_propertyComboBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_propertyComboBox.ItemHeight = 13
        Me.m_propertyComboBox.Location = New System.Drawing.Point(31, 70)
        Me.m_propertyComboBox.Name = "m_propertyComboBox"
        Me.m_propertyComboBox.Size = New System.Drawing.Size(152, 21)
        Me.m_propertyComboBox.TabIndex = 17
        '
        'FinderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 398)
        Me.Controls.Add(Me.m_findButton)
        Me.Controls.Add(Me.m_itemsCountLabel)
        Me.Controls.Add(Me.SearchResultLabel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.ValueTextBoxLabel)
        Me.Controls.Add(Me.m_valueTextBox)
        Me.Controls.Add(Me.ConditionComboBoxLabel)
        Me.Controls.Add(Me.PropertyComboBoxLabel)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.m_searchResultsListBox)
        Me.Controls.Add(Me.m_removeCriteriaButton)
        Me.Controls.Add(Me.m_addCriteriaButton)
        Me.Controls.Add(Me.m_criteriaListBox)
        Me.Controls.Add(Me.m_conditionComboBox)
        Me.Controls.Add(Me.m_propertyComboBox)
        Me.MaximumSize = New System.Drawing.Size(720, 436)
        Me.MinimumSize = New System.Drawing.Size(720, 436)
        Me.Name = "FinderForm"
        Me.Text = "FinderForm"
        Me.contextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents m_openFileToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents m_findButton As System.Windows.Forms.Button
    Private WithEvents m_itemsCountLabel As System.Windows.Forms.Label
    Private WithEvents SearchResultLabel As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents ValueTextBoxLabel As System.Windows.Forms.Label
    Private WithEvents m_valueTextBox As System.Windows.Forms.TextBox
    Private WithEvents ConditionComboBoxLabel As System.Windows.Forms.Label
    Private WithEvents PropertyComboBoxLabel As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents m_searchResultsListBox As System.Windows.Forms.ListBox
    Private WithEvents m_removeCriteriaButton As System.Windows.Forms.Button
    Private WithEvents m_addCriteriaButton As System.Windows.Forms.Button
    Private WithEvents m_criteriaListBox As System.Windows.Forms.ListBox
    Private WithEvents m_conditionComboBox As System.Windows.Forms.ComboBox
    Private WithEvents m_propertyComboBox As System.Windows.Forms.ComboBox
End Class

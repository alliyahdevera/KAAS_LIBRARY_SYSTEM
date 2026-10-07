Module ScreenFit
    ' designW/designH = the ClientSize in the form's Designer.vb
    Public Sub Apply(f As Form, designW As Integer, designH As Integer)
        Dim sx As Single = 1.0F, sy As Single = 1.0F
        If f.AutoScaleMode = AutoScaleMode.Font AndAlso
           f.AutoScaleDimensions.Width > 0 AndAlso f.AutoScaleDimensions.Height > 0 Then
            sx = f.CurrentAutoScaleDimensions.Width / f.AutoScaleDimensions.Width
            sy = f.CurrentAutoScaleDimensions.Height / f.AutoScaleDimensions.Height
        ElseIf f.AutoScaleMode = AutoScaleMode.Dpi Then
            sx = f.DeviceDpi / 96.0F
            sy = sx
        End If
        f.AutoScroll = True
        f.AutoScrollMinSize = New Size(CInt(designW * sx), CInt(designH * sy))
    End Sub
End Module
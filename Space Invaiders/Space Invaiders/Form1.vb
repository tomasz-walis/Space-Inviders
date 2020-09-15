Public Class AlienInvaiders



#Region "My Variables"

    Dim aliens(15) As PictureBox
    Dim reslocation(15) As System.Drawing.Point 'stores location of x nd y'
    Dim alienShot(15) As Boolean
    Dim alienShot2(15) As Label 'Array to store labels

    Dim M_Left As Boolean
    Dim M_Right As Boolean
    Dim move_alien As Integer = 10

    'BULETS'
    Dim Bulet As Boolean
    Dim Bullet1 As Boolean
    Dim Bullet2 As Boolean
    Dim Bullet3 As Boolean
    Dim Bullet4 As Boolean
    Dim Bullet5 As Boolean

    Dim alien_check As Integer 'var to check witch alien has been hit'
    Dim level As Integer
    Dim Level_Num As Integer = 1
    Dim Score As Integer
    Dim RandomNum As Integer

    'SCOREBOARD'
    Dim Score1 As Integer = 100
    Dim Score2 As Integer = 70
    Dim Score3 As Integer = 50
    Dim Score4 As Integer = 30
    Dim Score5 As Integer = 10

    Dim Name1 As String = "CPU"
    Dim Name2 As String = "CPU"
    Dim Name3 As String = "CPU"
    Dim Name4 As String = "CPU"
    Dim Name5 As String = "CPU"
#End Region




#Region "My Buttons"
    Private Sub btStart_Click(sender As Object, e As EventArgs) Handles btStart.Click
        'HIDES OR SHOWS COMPONENTS ON MAIN FORM'
        lbTitle.Hide()
        pbBackground.Hide()
        btStart.Hide()
        btQuit.Hide()
        PnSpace.Show()
        'starts the timer'
        tmMove.Enabled = True
        tmMove.Start()
    End Sub
    Private Sub btQuit_Click(sender As Object, e As EventArgs) Handles btQuit.Click
        End
    End Sub
    Private Sub btMainMenu_Click(sender As Object, e As EventArgs)
        PnSpace.Hide()
        pnScoreBoard.Hide()

        pbBackground.Show()
        lbTitle.Show()
        btStart.Show()
        btQuit.Show()
        resetgame() 'goes to resetgame sub'

    End Sub

#End Region





#Region "My Timers"

    Private Sub tmMove_Tick(sender As Object, e As EventArgs) Handles tmMove.Tick
        'MOVES THE SPACE SHIP AND BULETS LEFT'
        If M_Left = True Then
            pbGun.Left = pbGun.Left - 30
            lbresetbulet.Left = lbresetbulet.Left - 30
            If Bullet1 = False Then
                lbbulet1.Left = lbbulet1.Left - 30
            End If
            If Bullet2 = False Then
                lbbulet2.Left = lbbulet2.Left - 30
            End If
            If Bullet3 = False Then
                lbbulet3.Left = lbbulet3.Left - 30
            End If
            If Bullet4 = False Then
                lbbulet4.Left = lbbulet4.Left - 30
            End If
            If Bullet5 = False Then
                lbbulet5.Left = lbbulet5.Left - 30
            End If
        End If

        'MAKES SPACE SHIP AND BULETS TO NOT GO OVER LEFT EDGE OF SCREEN'
        If pbGun.Left < 0 Then
            pbGun.Left = pbGun.Left + 30
            lbresetbulet.Left = lbresetbulet.Left + 30
            If Bullet1 = False Then
                lbbulet1.Left = lbbulet1.Left + 30
            End If
            If Bullet2 = False Then
                lbbulet2.Left = lbbulet2.Left + 30
            End If
            If Bullet3 = False Then
                lbbulet3.Left = lbbulet3.Left + 30
            End If
            If Bullet4 = False Then
                lbbulet4.Left = lbbulet4.Left + 30
            End If
            If Bullet5 = False Then
                lbbulet5.Left = lbbulet5.Left + 30
            End If
        End If

        'MOVES THE SPACE SHIP AND BULETS RIGHT'
        If M_Right = True Then
            pbGun.Left = pbGun.Left + 30
            lbresetbulet.Left = lbresetbulet.Left + 30
            If Bullet1 = False Then
                lbbulet1.Left = lbbulet1.Left + 30
            End If
            If Bullet2 = False Then
                lbbulet2.Left = lbbulet2.Left + 30
            End If
            If Bullet3 = False Then
                lbbulet3.Left = lbbulet3.Left + 30
            End If
            If Bullet4 = False Then
                lbbulet4.Left = lbbulet4.Left + 30
            End If
            If Bullet5 = False Then
                lbbulet5.Left = lbbulet5.Left + 30
            End If
        End If

        'MAKES SPACE SHIP TO NOT GO OVER RIGHT EDGE OF SCREEN'
        If pbGun.Left > Me.Width - pbGun.Width Then
            pbGun.Left = pbGun.Left - 30
            lbresetbulet.Left = lbresetbulet.Left - 30
            If Bullet1 = False Then
                lbbulet1.Left = lbbulet1.Left - 30
            End If
            If Bullet2 = False Then
                lbbulet2.Left = lbbulet2.Left - 30
            End If
            If Bullet3 = False Then
                lbbulet3.Left = lbbulet3.Left - 30
            End If
            If Bullet4 = False Then
                lbbulet4.Left = lbbulet4.Left - 30
            End If
            If Bullet5 = False Then
                lbbulet5.Left = lbbulet5.Left - 30
            End If
        End If
        movealiens() 'reads movealiens sub'
        If Bulet = True Then
            checkbulet() 'if Bulet = True goes to  checkbulet sub'
        End If

        movebulet() 'reads movebuletsub'
        alienshoot()
    End Sub
    'SCORE BOARD TIMER'
    Private Sub tmScoreBoard_Tick(sender As Object, e As EventArgs) Handles tmScoreBoard.Tick
        tmScoreBoard.Stop()
        pnScoreBoard.Visible = True
    End Sub

#End Region






#Region "KEY INPUTS"
    Private Sub MoveB(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'SPACE SHIP AND BULETS LEFT OR RIGHT'
        If e.KeyValue = Keys.Left Then
            M_Left = True
        End If
        If e.KeyValue = Keys.Right Then
            M_Right = True
        End If
        If e.KeyValue = Keys.S Then
            Bulet = True

        End If
    End Sub

    Private Sub MoveStop(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        'SPACE SHIP AND BULLET STOPS WHEN KEYS NOT PRESSED'
        If e.KeyValue = Keys.Left Then
            M_Left = False
        End If
        If e.KeyValue = Keys.Right Then
            M_Right = False
        End If
        If e.KeyValue = Keys.S Then
            Bulet = False
        End If
    End Sub
#End Region




#Region "My Aliens, Bulets and other subs "
    Public Sub New() 'GOES TO SUBS'
        InitializeComponent()
        createarray()
        alienhit()
        dispscoreboard()


    End Sub
    'ARRAYS FOR ALIENS'
    Private Sub createarray()
        aliens(0) = pbAlien1
        aliens(1) = pbAlien2
        aliens(2) = pbAlien3
        aliens(3) = pbAlien4
        aliens(4) = pbAlien5
        aliens(5) = pbAlien6
        aliens(6) = pbAlien7
        aliens(7) = pbAlien8
        aliens(8) = pbAlien9
        aliens(9) = pbAlien10
        aliens(10) = pbAlien11
        aliens(11) = pbAlien12
        aliens(12) = pbAlien13
        aliens(13) = pbAlien14
        aliens(14) = pbAlien15
        aliens(15) = pbAlien16

        'checks coresponding coordinates of each PB'
        For A = 0 To 15
            reslocation(A) = aliens(A).Location
        Next

    End Sub
    'ARRAYS FOR ALIENS SHOT'
    Private Sub alienhit()
        alienShot2(0) = lbAs1
        alienShot2(1) = lbAs2
        alienShot2(2) = lbAs3
        alienShot2(3) = lbAs4
        alienShot2(4) = lbAs5
        alienShot2(5) = lbAs6
        alienShot2(6) = lbAs7
        alienShot2(7) = lbAs8
        alienShot2(8) = lbAs9
        alienShot2(9) = lbAs10
        alienShot2(10) = lbAs11
        alienShot2(11) = lbAs12
        alienShot2(12) = lbAs13
        alienShot2(13) = lbAs14
        alienShot2(14) = lbAs15
        alienShot2(15) = lbAs16


    End Sub
    Private Sub movealiens()
        For A = 0 To 15
            aliens(A).Left = aliens(A).Left + move_alien
            If alienShot(A) = False Then
                alienShot2(A).Left = alienShot2(A).Left + move_alien
            End If
            'GAME OVER WHEN ALIENS TOUCH SPACE SHIP'
            If aliens(A).Bounds.IntersectsWith(pbGun.Bounds) Then

                gameover() 'reads gameover sub'
            End If
        Next

        'Aliens move down when touch right side of form
        If pbAlien16.Left > Width - pbAlien16.Width Then
            move_alien = move_alien * -1
            For A = 0 To 15
                aliens(A).Top = aliens(A).Top + 25
                If alienShot(A) = False Then
                    alienShot2(A).Top = alienShot2(A).Top + 25
                End If
            Next
        End If
        'Aliens move down when touch left side of form'
        If pbAlien9.Left < 0 Then
            move_alien = move_alien * -1
            For I = 0 To 15
                aliens(I).Top = aliens(I).Top + 25
                If alienShot(I) = False Then
                    alienShot2(I).Top = alienShot2(I).Top + 25
                End If
            Next

        End If
    End Sub

    Private Sub checkbulet()
        Bulet = False 'Makes bulets not to shot all at once'
        If Bullet1 = False Then
            Bullet1 = True
            lbbulet1.Show()
            Exit Sub 'exits sub not to make other boolean var true'
        End If
        If Bullet2 = False Then
            Bullet2 = True
            lbbulet2.Show()
            Exit Sub
        End If
        If Bullet3 = False Then
            Bullet3 = True
            lbbulet3.Show()
            Exit Sub
        End If
        If Bullet4 = False Then
            Bullet4 = True
            lbbulet4.Show()
            Exit Sub
        End If
        If Bullet5 = False Then
            Bullet5 = True
            lbbulet5.Show()
            Exit Sub
        End If
    End Sub
    Private Sub movebulet()
        If Bullet1 = True Then
            lbbulet1.Top = lbbulet1.Top - 30
            'Hit Detection'
            For A = 0 To 15
                If lbbulet1.Bounds.IntersectsWith(aliens(A).Bounds) Then
                    alien_check = A 'checks which alien been hit'
                    Bulet1HIT() 'goes to Bulet1HIT Sub'
                End If
            Next
            'resets location of the bulet to lb reset bulet'
            If lbbulet1.Top < 0 Then
                lbbulet1.Hide()
                Bullet1 = False
                lbbulet1.Location = lbresetbulet.Location
            End If
        End If

        If Bullet2 = True Then
            lbbulet2.Top = lbbulet2.Top - 30
            For A = 0 To 15
                If lbbulet2.Bounds.IntersectsWith(aliens(A).Bounds) Then
                    alien_check = A
                    Bulet2HIT()
                End If
            Next
            If lbbulet2.Top < 0 Then
                lbbulet2.Hide()
                Bullet2 = False
                lbbulet2.Location = lbresetbulet.Location
            End If
        End If

        If Bullet3 = True Then
            lbbulet3.Top = lbbulet3.Top - 30
            For A = 0 To 15
                If lbbulet3.Bounds.IntersectsWith(aliens(A).Bounds) Then
                    alien_check = A
                    Bulet3HIT()
                End If
            Next
            If lbbulet3.Top < 0 Then
                lbbulet3.Hide()
                Bullet3 = False
                lbbulet3.Location = lbresetbulet.Location
            End If
        End If

        If Bullet4 = True Then
            lbbulet4.Top = lbbulet4.Top - 30
            For A = 0 To 15
                If lbbulet4.Bounds.IntersectsWith(aliens(A).Bounds) Then
                    alien_check = A
                    Bulet4HIT()
                End If
            Next
            If lbbulet4.Top < 0 Then
                lbbulet4.Hide()
                Bullet4 = False
                lbbulet4.Location = lbresetbulet.Location
            End If
        End If


        If Bullet5 = True Then
            lbbulet5.Top = lbbulet5.Top - 30
            For A = 0 To 15
                If lbbulet5.Bounds.IntersectsWith(aliens(A).Bounds) Then
                    alien_check = A
                    Bulet5HIT()
                End If
            Next
            If lbbulet5.Top < 0 Then
                lbbulet5.Hide()
                Bullet5 = False
                lbbulet5.Location = lbresetbulet.Location
            End If
        End If


    End Sub
    Private Sub Bulet1HIT()
        Bullet1 = False 'stops moving bulet up'
        lbbulet1.Hide()
        lbbulet1.Location = lbresetbulet.Location 'restarts to org location'
        aliens(alien_check).Top = aliens(alien_check).Top + 50000 'moves alien off screen when hit'
        level = level + 1
        If level = 16 Then
            levels() 'goes to levels sub'
        End If
        Score = Score + 1
        lbScore.Text = "SCORE: " & Score
    End Sub
    Private Sub Bulet2HIT()
        Bullet2 = False
        lbbulet2.Hide()
        lbbulet1.Location = lbresetbulet.Location
        aliens(alien_check).Top = aliens(alien_check).Top + 50000
        level = level + 1
        If level = 16 Then
            levels()
        End If
        Score = Score + 1
        lbScore.Text = "SCORE: " & Score
    End Sub
    Private Sub Bulet3HIT()
        Bullet3 = False
        lbbulet3.Hide()
        lbbulet3.Location = lbresetbulet.Location
        aliens(alien_check).Top = aliens(alien_check).Top + 50000
        level = level + 1
        If level = 16 Then
            levels()
        End If
        Score = Score + 1
        lbScore.Text = "SCORE: " & Score
    End Sub
    Private Sub Bulet4HIT()
        Bullet4 = False
        lbbulet4.Hide()
        lbbulet4.Location = lbresetbulet.Location
        aliens(alien_check).Top = aliens(alien_check).Top + 50000
        level = level + 1
        If level = 16 Then
            levels()
        End If
        Score = Score + 1
        lbScore.Text = "SCORE: " & Score
    End Sub
    Private Sub Bulet5HIT()
        Bullet5 = False
        lbbulet5.Hide()
        lbbulet5.Location = lbresetbulet.Location
        aliens(alien_check).Top = aliens(alien_check).Top + 50000
        level = level + 1
        If level = 16 Then
            levels()
        End If
        Score = Score + 1
        lbScore.Text = "SCORE: " & Score
    End Sub

    Private Sub gameover()
        tmMove.Stop() 'stops timer'
        pbGun.Image = My.Resources.expl 'changes PB'
        pbgameover.Show()
        tmScoreBoard.Enabled = True
        tmScoreBoard.Start()
    End Sub

    Private Sub levels()
        level = 0
        Level_Num = Level_Num + 1
        lblevel.Text = "LEVEL : " & Level_Num
        'moves aliens back to top'
        For A = 0 To 15
            aliens(A).Location = reslocation(A)
        Next
    End Sub

    Private Sub alienshoot()
        For A = 0 To 15
            If alienShot(A) = False Then
                'For Aliens shoot Randomizes numbers between 1 and 300'
                RandomNum = CInt(Int((300 * Rnd()) + 1))
                If RandomNum = 300 Then
                    alienShot(A) = True
                    alienShot2(A).Show()
                    'stops droping shots when invaider dies'
                    If aliens(A).Top > 300 Then
                        alienShot(A) = False
                        alienShot2(A).Hide()
                    End If
                End If
            End If
        Next
        For A = 0 To 15
            If alienShot(A) = True Then
                alienShot2(A).Top = alienShot2(A).Top + 25
                If alienShot2(A).Bounds.IntersectsWith(pbGun.Bounds) Then
                    gameover()
                End If
                'resets the shot back to invaider'
                If alienShot2(A).Top > Me.Height Then
                    alienShot(A) = False
                    alienShot2(A).Hide()
                    alienShot2(A).Location = aliens(A).Location
                    alienShot2(A).Top = alienShot2(A).Top + 80
                    alienShot2(A).Left = alienShot2(A).Left + 42

                End If
            End If
        Next
    End Sub
    Private Sub scorreboardlb()
        'Moves scores and names down the scoreboard'
        If Score > Score1 Then
            Score5 = Score4
            Score4 = Score3
            Score3 = Score2
            Score2 = Score1
            Score1 = Score

            Name5 = Name4
            Name4 = Name3
            Name3 = Name2
            Name2 = Name1
            Name1 = tbName.Text

            lbScore2.Text = Name1
            lbScore3.Text = Name2
            lbScore4.Text = Name3
            lbScore5.Text = Name4
            lbScore6.Text = Name5

            lbScore7.Text = Score1
            lbScore8.Text = Score2
            lbScore9.Text = Score3
            lbScore10.Text = Score4
            lbScore11.Text = Score5
            Exit Sub
        End If
        If Score > Score2 Then
            Score5 = Score4
            Score4 = Score3
            Score3 = Score2
            Score2 = Score

            Name5 = Name4
            Name4 = Name3
            Name3 = Name2
            Name2 = tbName.Text

            lbScore3.Text = Name2
            lbScore4.Text = Name3
            lbScore5.Text = Name4
            lbScore6.Text = Name5


            lbScore8.Text = Score2
            lbScore9.Text = Score3
            lbScore10.Text = Score4
            lbScore11.Text = Score5
            Exit Sub
        End If
        If Score > Score3 Then
            Score5 = Score4
            Score4 = Score3
            Score3 = Score

            Name5 = Name4
            Name4 = Name3
            Name3 = tbName.Text

            lbScore4.Text = Name3
            lbScore5.Text = Name4
            lbScore6.Text = Name5

            lbScore9.Text = Score3
            lbScore10.Text = Score4
            lbScore11.Text = Score5
            Exit Sub
        End If
        If Score > Score4 Then
            Score5 = Score4
            Score4 = Score

            Name5 = Name4
            Name4 = tbName.Text

            lbScore5.Text = Name4
            lbScore6.Text = Name5

            lbScore10.Text = Score4
            lbScore11.Text = Score5
            Exit Sub
        End If
        If Score > Score5 Then
            Score5 = Score
            Name5 = tbName.Text
            lbScore6.Text = Name5
            lbScore11.Text = Score5
            Exit Sub
        End If
    End Sub
    Private Sub dispscoreboard()
        lbScore2.Text = Name1
        lbScore3.Text = Name2
        lbScore4.Text = Name3
        lbScore5.Text = Name4
        lbScore6.Text = Name5

        lbScore7.Text = Score1
        lbScore8.Text = Score2
        lbScore9.Text = Score3
        lbScore10.Text = Score4
        lbScore11.Text = Score5
    End Sub
    Private Sub resetgame()
        pbGun.Image = My.Resources.Ship2
        Score = 0
        level = 1
        alien_check = 0
        pbgameover.Hide()
        Bulet = False
        Bullet1 = False
        Bullet2 = False
        Bullet3 = False
        Bullet4 = False
        Bullet5 = False
        lbbulet1.Location = lbresetbulet.Location
        lbbulet2.Location = lbresetbulet.Location
        lbbulet3.Location = lbresetbulet.Location
        lbbulet4.Location = lbresetbulet.Location
        lbbulet5.Location = lbresetbulet.Location
        lbScore.Text = "SCORE:" & Score
        'Ressets Aliens Location'
        For A = 0 To 15
            aliens(A).Location = reslocation(A)
            aliens(A).Show()
            alienShot(A) = False
            alienShot2(A).Hide()
            alienShot2(A).Location = aliens(A).Location
            alienShot2(A).Top = alienShot2(A).Top + 80
            alienShot2(A).Left = alienShot2(A).Left + 42

        Next



    End Sub
#End Region

    Private Sub AlienInvaiders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

    End Sub
#Region "Score Board"
    Private Sub tbName_KeyDown(sender As Object, e As KeyEventArgs) Handles tbName.KeyDown
        If e.KeyValue = Keys.Enter Then
            scorreboardlb() 'goes to sub scoreboardlb'
            lbScore2.Show()
            lbscore3.Show()
            lbScore4.Show()
            lbScore5.Show()
            lbScore6.Show()
            lbScore7.Show()
            lbScore8.Show()
            lbScore9.Show()
            lbScore10.Show()
            lbScore11.Show()

        End If
    End Sub



#End Region

   
    
End Class

Module Module1

    Sub Main()
        Dim a As UInteger ' Lower limit of safe readings
        Dim b As UInteger ' Upper limit of safe readings
        Dim n As UInteger ' Interference level value
        Dim c As UInteger = 0 ' Counter for safe readings
        Dim d As UInteger = 0 ' Variable to store the length of the safe reading segment
        Dim m As UInteger ' Local maximum length of the safe reading segment
        Dim max_len As UInteger = 0 ' final maximum of the length of the safe reading segment
        ' Data input
        Console.WriteLine("Enter the safety limits for readings")
        Console.Write("Lower limit: ")
        UInteger.TryParse(Console.ReadLine(), a)
        Console.Write("Upper limit: ")
        UInteger.TryParse(Console.ReadLine(), b)
        Console.WriteLine("Enter orbital station sensor readings")
        Console.WriteLine("0 - end data input")
        UInteger.TryParse(Console.ReadLine(), n) ' Input the first interference level value
        Do While (n <> 0) ' Input readings until the value is 0
            If ((n >= a) And (n <= b)) Then ' Condition for safe readings
                c += 1 ' Increment the safe readings counter
            Else
                d = c ' If readings are unsafe, store the count of safe readings
                c = 0 ' and reset the counter
            End If
            ' Determine the maximum length of the segment
            ' where readings are safe. If the counter was reset
            ' (the chain of safe data was interrupted), then the maximum length
            ' is the old counter value (variable "d").
            ' Otherwise, it is the current (new) counter value (variable "c").
            ' Intermediate result.
            If (d > c) Then
                m = d
            Else
                m = c
            End If
            'Final maximum length of the segment
            'where readings are safe.
            If (m > max_len) Then
                max_len = m
            End If
            UInteger.TryParse(Console.ReadLine(), n) ' Input the next data point
        Loop
        ' Display information on the screen.
        Console.WriteLine($"Length of the interval where all readings are safe: {max_len}")
        Console.Read() ' Pauses screen output until the "Enter" key is pressed
    End Sub

End Module

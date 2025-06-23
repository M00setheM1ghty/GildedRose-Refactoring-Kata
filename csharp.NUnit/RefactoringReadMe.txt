General: 

	Anstatt den String direkt zu vergleichen, könnte man Contains nutzen (ist aber eher eine Design-Frage)
	Die Konstanten könnten wir durch Variablen (z.B. als Properties innerhalb der Klasse) ersetzen. Dadurch wären sie zentral steuerbar und geben eine bessere Übersicht.


Der Code

if (item.Quality < 50)
{
    item.Quality++;
}

Kommt mehrfach vor. Hier könnten wir das Reduzieren basierend auf dem Limit mithilfe einer Methode auslagern und wiederverwenden.

Zeile 16:
	Hier eignet sich eine foreach-Schleife, da diese für das Arbeiten mit Listen bevorzugt wird.

Zeile: 25, 55
	Da sich bei Sulfuras weder sein "Verkaufsdatum" ändert, noch seine "Qualität" verschlechtert, würde ich im for-Loop als erstes Abfragen, ob der Name nicht "Sulfuras" ist.
	--> Der restliche Code wird anschließend innerhalb der Condition fortgeführt.

	Wäre mein Vorschlag, da damit gleich zu beginn ausgeschlossen wird, dass Sulfuras im fortlaufenden Code nicht weiter behaldet werden muss.

Nach der Abfrage könnte man zunächst die Zeile für das Abziehen des Sell-Ins schreiben. Damit die Struktur klarer ist (zuerst wird Sell-In reduziert, dann wird die Qualität evaluiert).

Zeile : 18

	Hier könnte man die Abfrage zu Items.Quality in die obere Condition inkludieren. Somit hätte man nur eine Abfrage für den Qualitätsabstieg

Zeile 36:

	statt +1 könnte man ++ machen.
	Man könnte die Bedingung für <6 in die obere Abfrage verschachteln, da sie ja sowieso nur auftritt, wenn <11 gilt.
	Wie auch bei Ln 18 erwähnt, könnte man die Abfrage zur Qualität in die übergeordneten Abfragen mittels && verknüpfen, damit es nicht so verschachtelt ist.

	Da es hier um die Quality

Ln 60-68:
	statt -1 könnte man auch -- schreiben.
	Absurd stark verschachtelt
	-->	Gleiches Spiel wie bei Ln18 (If-Conditions kombinieren)


Ln 76: 
	Qualität eventuell gleich 0 setzen. Das subtrahieren mit dem eigenen Wert ist unnötig umständlich.

Ln 83:
	++ statt +1
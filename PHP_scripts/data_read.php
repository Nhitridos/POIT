<?php
	// Nacitanie vsetkych udajov z DB a ich nasledny vypis v prehliadaci

	$servername = "localhost";
	$username = "root";
	$password = "kiklopko1";
	$dbName = "unitytestdb";
	
	// Nadviazanie komunikacie s DB
	$conn = new mysqli($servername, $username, $password, $dbName);
	// Kontrola
	if(!$conn){
		die("Connection failed". mysqli_connection_error());
	}
	
	// Select vsetkych ID, rychlosti a X, Y, Z koordinatov z tabulky
	$sql = "SELECT ID, Velocity, X, Y, Z FROM Velocity";
	$result = mysqli_query($conn, $sql);
	
	// Vypis vsetkych selecnutych dat v prehliadaci, pricom data pre
	// kazde ID sa zapisuju do noveho riadku a udaje v riadku su oddelene "|"
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo "ID: ".$row['ID'] . " | Velocity: ".$row['Velocity'] . " | X: ".$row['X'] . " | Y: ".$row['Y'] . " | Z: ".$row['Z'] . "<br>";
		}
	}
?>
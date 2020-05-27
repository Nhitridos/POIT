<?php
	// Select vsetkych zaznamov rychlosti z databazy za ucelom dalsieho 
	// vyuzitia v Unity (/C#_scripts/DB_scripts/DataLoader.cs) na vyber
	// zelanej hodnoty rychlosti na zaklade jej ID

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
	
	// Select vsetkych ID a rychlosti z tabulky
	$sql = "SELECT ID, Velocity FROM Velocity";
	$result = mysqli_query($conn, $sql);
	
	// Vypis vsetkych selecnutych dat v prehliadaci oddelenych ";"
	// Takato struktura zapisu dat je nutne pre dalsie vyuzitie
	// na vyber zelanej hodnoty rychlosti v Unity
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo "ID:".$row['ID'] . "|Velocity:".$row['Velocity'] . ";";
		}
	}
?>
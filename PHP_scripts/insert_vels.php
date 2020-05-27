<?php
	// Zapis dat z Unity do DB (/C#_scripts/DB_scrips/DataInserter.cs) 
	// a do suboru

	$servername = "localhost";
	$username = "root";
	$password = "kiklopko1";
	$dbName = "unitytestdb";
	
	// Deklaracia premennych, ktore sa budu vyuzitim metody POST 
	// (Hypertext Transfer Protocol) prenasat do DB (a taktiez 
	// zapisovat do suboru)
	$velocity_add = $_POST["velPost"];
	$x_add = $_POST["xPost"];
	$y_add = $_POST["yPost"];
	$z_add = $_POST["zPost"];
	
	// Priprava suboru na zapis dat
	$dPath = getcwd();
	$myfile = fopen($dPath . "\log.txt", "a");
	
	// Nadviazanie komunikacie s DB
	$conn = new mysqli($servername, $username, $password, $dbName);
	// Kontrola
	if(!$conn){
		die("Connection failed". mysqli_connection_error());
	}
	
	// Zapis dat do DB
	$sql = "INSERT INTO velocity(Velocity, X, Y, Z) 
			VALUES ('". $velocity_add ."','".$x_add."','".$y_add."','".$z_add."')";
	$result = mysqli_query($conn, $sql);
	
	// Zapis dat do suboru
	$txt = "Velocity: " . $velocity_add . " | X: " . $x_add . " | Y: " . $y_add . " | Z: " . $z_add . "\n";
	fwrite($myfile, $txt);
	fclose($myfile);
?>
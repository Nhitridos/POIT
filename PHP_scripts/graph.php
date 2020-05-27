<?php
require_once("phpChart_Lite/conf.php");
?>

<!DOCTYPE HTML>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>phpChart - Basic Chart</title>
</head>
<body>

<?php
	// Vykrelovanie grafu priebehu rychlosti vyuzitim dat v DB

	$servername = "localhost";
	$username = "root";
	$password = "kiklopko1";
	$dbName = "unitytestdb";
	
	// Deklaracia pomocnych premennych
	$npoints = 0;
	$y = array();
	
	// Nadviazanie komunikacie s DB
	$conn = new mysqli($servername, $username, $password, $dbName);
	// Kontrola
	if(!$conn){
		die("Connection failed". mysqli_connection_error());
	}
	
	// Select vsetkych ID a rychlosti z tabulky
	$sql = "SELECT ID, Velocity FROM Velocity";
	$result = mysqli_query($conn, $sql);
	
	// Zistenie aktualneho poctu udajov a naplenie pola $y
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			$npoints++;
			$y[$npoints] = $row['Velocity'];
		}
	}
	
	// Funkcia pripravujuca DataArray, ktory bude vyuzity na vykreslenie
	// grafu priebehu rychlosti v prehliadaci
	function BuildDataArray($n, $y_arr) {
            $GraphData = array();
			$i=0;
            for($i = 0; $i < $n; $i++) {
				$GraphData[$i] = floatval($y_arr[$i+1]);
            }     
			return $GraphData;
    }
         
    $GraphData = BuildDataArray($npoints, $y);
	
	// Vykreslenie grafu v prehliadaci
	$pc = new C_PhpChartX(array($GraphData),'basic_chart');
	// Pridanie nadpisu a popisu osi grafu
    $pc->set_title(array('text'=>'Graph of Velocity'));    
    $pc->set_axes(array(
    		'xaxis'=> array('label'=> 'No'),
    		'yaxis'=> array('label'=>'Velocity')));
    
    $pc->draw(); 
	
?>

</body>
</html>
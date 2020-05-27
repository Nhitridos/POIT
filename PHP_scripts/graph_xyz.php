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
	// Vykrelovanie grafu priebehu X, Y, Z suradnic auta vyuzitim dat v DB

	$servername = "localhost";
	$username = "root";
	$password = "kiklopko1";
	$dbName = "unitytestdb";
	
	// Deklaracia pomocnych premennych
	$npoints = 0;
	$xd = array();
	$yd = array();
	$zd = array();
	
	// Nadviazanie komunikacie s DB
	$conn = new mysqli($servername, $username, $password, $dbName);
	// Kontrola
	if(!$conn){
		die("Connection failed". mysqli_connection_error());
	}
	
	// Select vsetkych ID a X, Y, Z suradnic z tabulky
	$sql = "SELECT ID, X, Y, Z FROM Velocity";
	$result = mysqli_query($conn, $sql);
	
	// Zistenie aktualneho poctu udajov a naplenie poli $x, $y, $z
	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			$npoints++;
			$xd[$npoints] = $row['X'];
			$yd[$npoints] = $row['Y'];
			$zd[$npoints] = $row['Z'];
		}
	}
	
	// Funkcia pripravujuca DataArray, ktory bude vyuzity na vykreslenie
	// grafu priebehu X, Y, Z suradnic auta v prehliadaci
	function BuildDataArray($n, $data_arr) {
            $GraphData = array();
			$i=0;
            for($i = 0; $i < $n; $i++) {
				$GraphData[$i] = floatval($data_arr[$i+1]);
            }
			return $GraphData;
    }
	
    $GraphDataX = BuildDataArray($npoints, $xd);
	$GraphDataY = BuildDataArray($npoints, $yd);
	$GraphDataZ = BuildDataArray($npoints, $zd);
	
	// Vykreslenie grafu v prehliadaci
	$pc = new C_PhpChartX(array($GraphDataX,$GraphDataY,$GraphDataZ),'basic_chart');
	// Pridanie nadpisu, popisu osi a legendy grafu
    $pc->set_title(array('text'=>'Graph of Coords'));    
    $pc->set_axes(array(
    		'xaxis'=> array('label'=> 'No'),
    		'yaxis'=> array('label'=>'Coords')));
	$pc->set_legend(array('show'=>true));
	$pc->add_series(array('label'=>'x'));
    $pc->add_series(array('label'=>'y'));
    $pc->add_series(array('label'=>'z'));
    
    $pc->draw(); 
	
?>

</body>
</html>
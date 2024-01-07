<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";


$silinecekDers = $_POST["silinecekDers"];
$silinecekHoca = $_POST["silinecekHoca"];
$silinecekSinif = $_POST["silinecekSinif"];
$silinecekSaat = $_POST["silinecekSaat"];
$silinecekGun = $_POST["silinecekGun"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection


  
  $sql2 = "DELETE k
  FROM kisitlar k
  JOIN dersler d ON k.Ders_ID = d.Ders_ID
  JOIN hocalar h ON k.Hoca_ID = h.Hoca_ID
  JOIN siniflar s ON k.Sinif_ID = s.Sinif_ID
  WHERE d.Ders_Adi = '" . $silinecekDers . "'
    AND h.Hoca_Adi = '" . $silinecekHoca . "'
    AND k.Saat = '" . $silinecekSaat . "'
    AND k.Gun = '" . $silinecekGun . "'
    AND s.Sinif_Adi = '" . $silinecekSinif . "';"
  ;
  if ($conn->query($sql2) === TRUE) {
    echo $silinecekDers . "adlı ders silindi";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
    
      

$conn->close();
?>

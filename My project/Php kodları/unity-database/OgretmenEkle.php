<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$HocaAdi = $_POST["HocaAdi"];
$HocaSifre = $_POST["HocaSifre"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Hoca_Adi FROM hocalar WHERE Hoca_Adi = '" . $HocaAdi . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  echo "Bu isimde bir hoca zaten var";

    
      
} else {

  $sql2 = "INSERT INTO hocalar (Hoca_Adi, Hoca_Sifre) VALUES ('" . $HocaAdi . "', '" . $HocaSifre . "')";
  if ($conn->query($sql2) === TRUE) {
    echo "Yeni öğretmen oluşturuldu";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}
$conn->close();
?>

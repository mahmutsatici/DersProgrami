<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$SinifAdi = $_POST["SinifAdi"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT Sinif_Adi FROM siniflar WHERE Sinif_Adi = '" . $SinifAdi . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  echo "Bu isimde bir sınıf zaten var";

    
      
} else {

  $sql2 = "INSERT INTO siniflar (Sinif_Adi) VALUES ('" . $SinifAdi . "')";
  if ($conn->query($sql2) === TRUE) {
    echo "Yeni sınıf oluşturuldu";
  } else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
  }
}
$conn->close();
?>

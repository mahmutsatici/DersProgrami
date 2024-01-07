<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity_database";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT password FROM users WHERE username = '" . $loginUser . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while ($row = $result->fetch_assoc()) {
    if ($row["password"] == $loginPass) {

      echo "Giriş Başarılı";
        //girişten sonraki işlemleri yapmamız gereken yer

    } else {
      echo "Yanlış Şifre!";
    }
  }
} else {
  echo "Kullanıcı Adı Bulunamadı";
}
$conn->close();
?>

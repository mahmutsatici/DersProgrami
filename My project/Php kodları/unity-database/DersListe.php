<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$connection = new mysqli($servername, $username, $password, $dbname);
$sql="SELECT * FROM dersler ORDER BY Ders_ID DESC";
$result = mysqli_query($connection,$sql);

if ($result) {
    while ($row = mysqli_fetch_assoc($result)) {
        echo  $row["Ders_Adi"] . "*";
    }
}else {
    echo "error";
}

?>
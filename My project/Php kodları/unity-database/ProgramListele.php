<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "ders_plani";

$connection = new mysqli($servername, $username, $password, $dbname);

// Hata kontrolü
if ($connection->connect_error) {
    die("Bağlantı hatası: " . $connection->connect_error);
}

$sql = "SELECT d.Ders_Adi, h.Hoca_Adi, s.Sinif_Adi, k.Gun, k.Saat
FROM kisitlar k
    INNER JOIN dersler d ON k.Ders_ID = d.Ders_ID
    INNER JOIN hocalar h ON k.Hoca_ID = h.Hoca_ID
    INNER JOIN siniflar s ON k.Sinif_ID = s.Sinif_ID
ORDER BY k.Saat ASC, k.Kisit_ID DESC;";

$result = $connection->query($sql);

if ($result) {
    while ($row = $result->fetch_assoc()) {
        echo $row["Ders_Adi"] . "*" . $row["Hoca_Adi"] . "," .$row["Sinif_Adi"] . "|" .$row["Gun"] . "/" .$row["Saat"] . "+";
    }
} else {
    echo "Hata: " . $connection->error;
}

$connection->close();
?>
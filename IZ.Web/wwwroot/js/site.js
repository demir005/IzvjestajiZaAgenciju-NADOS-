var Glavna = [];
var seperatorskiRed1;

Glavna.VratiHeader = function (workbook) {
    var heder = XLSX.utils.sheet_to_json(workbook.Sheets[workbook.SheetNames[0]], { header: 1, raw: false });
    var pocetniRedHeadera = 0;

    pocetniRedHeadera = Glavna.VratiPocetniRedHeadera(heder);

    for (var j = 1; j < heder.length; j++) { //krece od drugog reda jer je prvi garant header
        if (heder[j].length == 0) continue;
        //if (pocetniRedHeadera == 0) {
        //    if (heder[j][heder[j].length - 1] == "u KM") {
        //        pocetniRedHeadera = j;
        //    }
        //    continue; //nastavi jer jos nije nasao pocetak
        //}

        var seperatorskiRed = true;

        var z = 0;
        for (var k = 0; k < heder[j].length; k++) {
            if (heder[j][k] == null) {
                z--;
            }

            if (!(heder[j][k] == z + 1 || heder[j][k] == null)) {
                seperatorskiRed = false;
                break;
            }
            z++;
        }
        if (seperatorskiRed) {
            heder.length = j;
            seperatorskiRed1 = j;
            break;
        }
    }

    if (pocetniRedHeadera != 0) {
        return heder.slice(pocetniRedHeadera + 1);
    } else {
        return null;
    }
}

Glavna.JeLiRedSeperatorski = function (red) {
    var seperatorskiRed = true;

    var z = 0;
    for (var k = 0; k < red.length; k++) {
        if (red[k] == null) {
            z--;
        }

        if (!(red[k] == z + 1 || red[k] == null)) {
            seperatorskiRed = false;
            break;
        }
        z++;
    }

    return seperatorskiRed;
}

Glavna.EXCELuXML = function (excelData) {
    var dataArr = excelData;
    var heading = dataArr[0];

    var data = dataArr.splice(1, dataArr.length - 1);
    var sve = document.createElement("sve");
    var xmlData = document.createElement("Dio2Podaci");

    for (var i = 0; i < data.length; i++) {
        var d = data[i];
        var productData = document.createElement("Podaci");
        for (var j = 0; j < d.length; j++) {

            if (j == 1) {
                if (heading[j]) {
                    let t = heading[j].normalize('NFKD').replace(/[^\w]/g, '');
                    var tag = document.createElement(t.replace(/\s/g, ""));
                }
            } else {
                if (heading[j]) {
                    let t = heading[j].normalize('NFKD').replace(/[^\w]/g, '');
                    var tag = document.createElement(t.replace(/\s/g, ""));
                }
                tag.innerHTML = d[j] ? d[j] : '';
            }

            productData.appendChild(tag);
        }
        xmlData.appendChild(productData);
    }
    sve.appendChild(xmlData);
    return '<?xml version="1.0" encoding="UTF-8"?>' + sve.innerHTML;
}

Glavna.EXCELuXML2 = function (excelData, pocetnaKolona = 0) { // kao prethodna ali zadrzava velika slova

    var dataArr = excelData;
    var heading = dataArr[0];

    var data = dataArr.splice(1, dataArr.length - 1);
    var xmlData = "<Dio2Podaci>";

    productData = "";
    for (var i = 0; i < data.length; i++) {
        var d = data[i];
        if (d.length == 0) continue;

        if (Glavna.JeLiRedSeperatorski(data[i])) continue;

        productData += "<Podaci>";

        var tag = "";
        for (var j = pocetnaKolona; j < d.length; j++) {
            if (heading[j]) {
                let t = heading[j].normalize('NFKD').replace(/[^a-zA-Z]+/g, '');//.replace(/[^\w]/g, '');
                tag += "<" + t.replace(/\s/g, "") + ">";

                tag += d[j] ? d[j] : '';
                tag += "</" + t.replace(/\s/g, "") + ">";
            }
        }

        productData += tag;
        productData += "</Podaci>";
    }

    xmlData += productData;
    xmlData += "</Dio2Podaci>";

    if (Glavna.ValidanXML(xmlData)) {
        return xmlData;
    } else {
        return null;
    }
}

Glavna.VratiPocetniRedHeadera = function (heder) {
    var pocetniRedHeadera = 0;
    for (var j = 1; j < heder.length; j++) { //krece od drugog reda jer je prvi garant header
        if (heder[j].length == 0) continue;
        if (pocetniRedHeadera == 0) {
            if (heder[j][heder[j].length - 1] == "u KM") {
                return j;
            }
        }
    }
}

Glavna.ValidanXML = function (xmlData) {
    var oParser = new DOMParser();
    var oDOM = oParser.parseFromString(xmlData, "text/xml");

    return oDOM.getElementsByTagName('parsererror').length ? false : true;
}

Glavna.Dio1PeriodSifra = function (datumOd, datumDo) {
    let dio1 = "<Dio1PeriodSifra>";

    datum1 = "<DatumOd>" + datumOd + "</DatumOd>";
    datum2 = "<DatumDo>" + datumDo + "</DatumDo>";

    dio1 += datum1 + datum2 + "</Dio1PeriodSifra>";

    return dio1;
}

Glavna.FormatirajXML = function (xml, tab) { // tab = optional indent value, default is tab (\t)
    var formatted = '', indent = '';
    tab = tab || '\t';
    xml.split(/>\s*</).forEach(function (node) {
        if (node.match(/^\/\w/)) indent = indent.substring(tab.length); // decrease indent by one 'tab'
        formatted += indent + '<' + node + '>\r\n';
        if (node.match(/^<?\w[^>]*[^\/]$/)) indent += tab;              // increase indent
    });
    return formatted.substring(1, formatted.length - 3);
}

Glavna.PrekiniJSONObjakatKodPraznogRedaNaDnu = function (jsonObj) {
    var prekiniDnoRed = jsonObj.length; // na dnu kad se stave info o mjestu i potpisi nekakvi izmedju bude prazan red pa tu prekidam
    // ako nema prazan red uzimam broj redova koliko je i doslo odnosno jsonObj.length

    // ako ima dno praznih redova na dnu odsjec ih:
    var odsjeci = 0;
    for (i = jsonObj.length - 1; i > 0; i--) {
        if (jsonObj[i].length == 0) {
            odsjeci++;
        }
    }
    jsonObj.length = jsonObj.length - odsjeci;
    // ako ima dno praznih redova na dnu odsjec ih KRAJ

    for (j = jsonObj.length - 1; j > 0; j--) {
        if (jsonObj[j].length == 0) {
            jsonObj.length = j + 1;
            return jsonObj;
        }
    }
    return jsonObj;
}

Glavna.VratiSamoPodatke = function (jsonObj) {
    //console.log(seperatorskiRed1);
    //console.log(jsonObj);
    //console.log(jsonObj.slice(seperatorskiRed1));
    var nizObj = [];

    jsonObj = Glavna.PrekiniJSONObjakatKodPraznogRedaNaDnu(jsonObj.slice(seperatorskiRed1));

    //console.log(jsonObj);

    duzinaRedaSaBr = jsonObj[0].length;
    var oduzmi = 0;

    for (var t = 0; t < jsonObj[0].length; t++) {
        console.log(jsonObj[0]);

        try {
            jsonObj[0][t].length;
        } catch{
            duzinaRedaSaBr--;
            oduzmi++;
        }

    }

    for (var i = 1; i < jsonObj.length; i++) { // prolazi kroz redove
        var obj = {};
        for (j = 0; j < jsonObj[i].length; j++) { // kolone

            //if (!jsonObj[0][j]) {
            //    duzinaRedaSaBr++; 
            //    continue;
            //}

            if (jsonObj[0][j]) {
                obj["K" + jsonObj[0][j]] = jsonObj[i][j] ? jsonObj[i][j] : null; // ako je neki izmedju popunjenih K-ova undefined stavi ga na null
            }

            if (j == jsonObj[i].length - 1 && jsonObj[i].length < duzinaRedaSaBr + oduzmi) { // ako je posljednji popunjen npr K3 a ukupno ima 5 kolona rucno donosim K4 K5 i postavljam ih na null
                // ako je j posljednji za tu kolonu i ako taj red ima manje kolona od onog nultog sa brojevima 1,2,3,4...
                // idi i dodaji do kraja null

                for (var k = parseInt(jsonObj[0][j]) + 1; k <= duzinaRedaSaBr; k++) {
                    obj["K" + k] = null;
                }
            }
        }
        //console.log(obj);
        nizObj.push(obj);
    }
    //console.log(nizObj);
    return JSON.stringify(nizObj);
}
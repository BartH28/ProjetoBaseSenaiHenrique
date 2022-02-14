import axios from "axios";

export const LerConteudoDaImagem = async(FormData) => {
   
    let resultado;

    await axios({
        method : "POST",
        url : "https://ocrhenrique.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data :  FormData,
        headers: {
            "Content-Type" : "multipart/form-data",
            "Ocp-Apim-Subscription-Key" : "72d302189ad2462686edb9588312fd9a"
        }
    }).then(response => {
        // console.log(response)
        resultado = FiltrarOB3(response.data);
    })
    .catch(erro => console.log(erro))

    return(resultado);
}

export const FiltrarOB3 = (obj) => {
    
    let resultado;

    obj.regions.forEach(region => {
        region.lines.forEach(line => {
            line.words.forEach(word => {
                if(word.text[0] === "1" && word.text[1] === "2" ){
                    resultado = word.text;
                }
            })
        })
    });

    return(resultado)
}
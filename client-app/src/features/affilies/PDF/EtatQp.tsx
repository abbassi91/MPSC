import { pdf } from '@react-pdf/renderer';

const saveBlob = (blob:any, filename:string) => {
  var a = document.createElement("a");
  document.body.appendChild(a);
  a.style.display = "none";
  let url = window.URL.createObjectURL(blob);
  a.href = url;
  //a.download = filename;
  //a.click();
  //window.URL.revokeObjectURL(url);
  window.open(url,`_blank`);
};

export const savePdf = async (document:any, filename:any) => {
  saveBlob(await pdf(document).toBlob(), filename);
  
};


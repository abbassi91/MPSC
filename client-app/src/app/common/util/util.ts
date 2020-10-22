

import { IAffilie } from "../../models/affilie";

export const combineDateAndTime = (date: Date, time: Date) => {
    // const timeString = time.getHours() + ':' + time.getMinutes() + ':00';

    // const year = date.getFullYear();
    // const month = date.getMonth() + 1;
    // const day = date.getDate();
    // const dateString = `${year}-${month}-${day}`;

    const dateString = date.toISOString().split('T')[0];
    const timeString = time.toISOString().split('T')[1];

    return new Date(dateString + 'T' + timeString);
}



export const setAffilieProps = (affilie: IAffilie) => {
  affilie.dateNaissance = new Date(affilie.dateNaissance);

  return affilie;
}


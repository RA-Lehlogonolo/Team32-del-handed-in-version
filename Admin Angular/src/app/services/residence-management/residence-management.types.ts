export interface Residence{
  id: number,
  name: string,
  address: string,
  campusName: string,
  campusId: number,
  residenceType: string,
  residenceTypeId: number
}

export interface Block{
  residenceId: any;
  id: number,
  name: string,
  residenceTypeId: number
}

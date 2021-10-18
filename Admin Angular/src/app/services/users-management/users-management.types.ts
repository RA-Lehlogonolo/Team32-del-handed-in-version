export interface HouseParent {
  id: number,
  appUserId: string,
  username: string,
  name: string,
  surname: string,
  emailAddress: string,
  phoneNumber: string,
  autoAssignedPassword: string,
  residenceName: string;
}

export interface Student {
  id: number,
  appUserId: string,
  studentNumber: string,
  name: string,
  surname: string,
  emailAddress: string,
  phoneNumber: string,
  autoAssignedPassword: string,
  residenceName: string,
  facultyName: string,
  studentRole: string,
  levelOfStudy: string,
}

export interface BuildingCoordinator {
  id: number,
  appUserId: string,
  username: string,
  name: string,
  surname: string,
  emailAddress: string,
  phoneNumber: string,
  autoAssignedPassword: string,
  residenceName: string;
}

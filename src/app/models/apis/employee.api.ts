export interface EmployeeViewModel {
  id: string,
  firstName: string,
  lastName: string,
  fatherName: string,
  email: string,
  dob: string,
  address: string,
  departmentNames: string,
  positionNames: string
}
interface EmployeeCreateViewModel {
  firstName: string
  lastName: string
  fatherName: string
  email: string
  dob: string
  address: string
  departmentPositionIds: string[]
}
interface EmployeeSearchViewModel {
  all: boolean
  id: string
  name: string
  departmentId: string
  positionId: string
}

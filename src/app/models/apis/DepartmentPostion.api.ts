import { Department } from "./Department.api"
import { Position } from "./Position.api"

export interface DepartmentPosition{
  departmentId:string,
  positionId:string,
  department:Department,
  position:Position
  id:string
}

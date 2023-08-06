export interface SuccessWarper<T>{
  status:200
  data:T
}
export interface FailWarper{
  status:400,
  message:string
}

export type ApiWarper<T>= SuccessWarper<T>|FailWarper;

export type ApiMessage=SuccessWarper<string>|FailWarper;

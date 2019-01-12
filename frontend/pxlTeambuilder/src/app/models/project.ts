export class Project{

    private id : string;
    private userId : number;
    private title : string;
    private description : string;
    private maxStudentsPerGroup : number;

    constructor(){}

    public set Id(id : string){
        this.id = id;
    }

    public set UserId(userId : number){
        this.userId = userId;
    }

    public set Title(title : string){
        this.title = title;
    }

    public set Description(description : string){
        this.description = description;
    }

    public set MaxStudentsPerGroup(maxStudentsPerGroup : number){
        this.maxStudentsPerGroup = maxStudentsPerGroup;
    }

    public get Id(){
        return this.id;
    }

    public get UserId(){
        return this.userId;
    }

    public get Title(){
        return this.title;
    }

    public get Description(){
        return this.description;
    }

    public get MaxStudentsPerGroup(){
        return this.maxStudentsPerGroup;
    }
}
export class User{

    private id : number;
    private name : string;
    private email : string;
    private role : string;

    constructor(){}

    get Id(){
        return this.id;
    }

    get Name(){
        return this.name;
    }

    get Email(){
        return this.email;
    }

    get Role(){
        return this.role.toLowerCase();
    }

    set Id(id : number){
        this.id = id;
    }

    set Name(name : string){
        this.name = name;
    }

    set Email(email : string){
        this.email = email;
    }

    set Role(role : string){
        this.role = role;
    }
}
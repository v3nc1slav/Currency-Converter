export async function home() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        dropdown: await this.load("./templates/dropdown.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    const token = localStorage.getItem("userToken");
    this.partial("./templates/Home/home.hbs");
    
}
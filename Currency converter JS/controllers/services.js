export async function services() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    const token = localStorage.getItem("userToken");
    this.partial("./templates/Services/services.hbs");
    
}
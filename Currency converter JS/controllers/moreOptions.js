export async function moreOptions() {
    this.partials = {
        header: await this.load("./templates/common/header.hbs"),
        footer: await this.load("./templates/common/footer.hbs")
    };

    const token = localStorage.getItem("userToken");
    this.partial("./templates/More options/moreOptions.hbs");
    
}
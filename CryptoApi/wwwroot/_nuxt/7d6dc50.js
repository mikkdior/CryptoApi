(window.webpackJsonp=window.webpackJsonp||[]).push([[68,19],{1130:function(t,e,n){t.exports=n.p+"img/contacts-bg.5f7758c.svg"},1367:function(t,e,n){var content=n(1513);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[t.i,content,""]]),content.locals&&(t.exports=content.locals);(0,n(8).default)("95eeb422",content,!0,{sourceMap:!1})},1512:function(t,e,n){"use strict";n(1367)},1513:function(t,e,n){var r=n(7),o=n(79),c=n(1130),l=r(!1),m=o(c);l.push([t.i,".contacts_wrapper{margin:56px 0 0;width:100%}@media only screen and (min-width:992px){.contacts_wrapper{max-width:670px}}.contacts_section{position:relative;z-index:1;padding:0 15px}.contacts_section:before{background-size:cover;background-image:url("+m+');position:absolute;width:531px;height:616px;right:-13px;top:0;z-index:-1}@media only screen and (min-width:992px){.contacts_section:before{display:block;content:""}}.contacts_title{font-weight:900;font-size:32px;line-height:120%;letter-spacing:-.03em;color:#fff}@media only screen and (min-width:992px){.contacts_title{font-size:56px}}.contacts_description{font-size:16px;line-height:160%;color:hsla(0,0%,100%,.6);font-weight:400}.contacts_description a{text-decoration:underline;color:hsla(0,0%,100%,.6)}.contacts_info{display:flex;margin:0 0 32px}.contacts_infoItem{padding:0 25px 0 0}@media only screen and (min-width:768px){.contacts_infoItem{padding:0 80px 0 0}}.contacts_infoItemTitle{font-weight:600;font-size:16px;line-height:120%;margin:0 0 16px;color:#fff}@media only screen and (min-width:768px){.contacts_infoItemTitle{font-size:24px}}.contacts_infoItemDesc{font-size:16px;line-height:120%;color:#fff;font-weight:400}@media only screen and (min-width:768px){.contacts_infoItemDesc{font-size:24px}}.contacts_infoItemDescLink{text-decoration:underline!important}.contacts_form{margin:24px 0 0}.contacts_formInputs{display:flex;margin:0 0 8px;flex-direction:column}@media only screen and (min-width:768px){.contacts_formInputs{flex-direction:row;margin:0 0 16px}}.contacts_formInputs .contacts_formInput{width:100%;flex-direction:column;display:flex}@media only screen and (min-width:768px){.contacts_formInputs .contacts_formInput{width:50%}}.contacts_formInputs .contacts_formInput:first-child{margin:0 0 8px}@media only screen and (min-width:768px){.contacts_formInputs .contacts_formInput:first-child{padding:0 8px 0 0;margin:0}}@media only screen and (min-width:768px){.contacts_formInputs .contacts_formInput:last-child{padding:0 0 0 8px}}.contacts_formSubmit{margin:16px 0 0}.contacts_formInputError{font-size:12px;color:#f13c3c}.contacts_formInputSucces{font-size:16px;line-height:137%;color:#b7f348;margin:0 0 24px}',""]),t.exports=l},1719:function(t,e,n){"use strict";n.r(e);n(12),n(9),n(13),n(18),n(10),n(19);var r=n(3),o=(n(30),n(66),n(959)),c=n(4),l=n(149);function m(object,t){var e=Object.keys(object);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(object);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(object,t).enumerable}))),e.push.apply(e,n)}return e}function d(t){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?m(Object(source),!0).forEach((function(e){Object(r.a)(t,e,source[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(source)):m(Object(source)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(source,e))}))}return t}var f={name:"Contacts",layout:"default",components:{Breadcrumbs:o.default},data:function(){return{form:{name:"",email:"",textarea:"",formSubmit:!1}}},validations:{form:{name:{required:l.required,minLength:Object(l.minLength)(2)},email:{required:l.required,email:l.email},textarea:{required:l.required}}},mounted:function(){var script=document.createElement("script");script.src="https://js.hsforms.net/forms/shell.js",document.body.appendChild(script),script.addEventListener("load",(function(){window.hbspt&&window.hbspt.forms.create({region:"na1",portalId:"14565770",formId:"67eda9f7-3409-48ed-8564-d023b7adad71",target:"#hubspotForm"})}))},methods:d(d({},Object(c.b)("app",["sendSupportMessage"])),{},{submit:function(){var t=this;this.$v.form.$touch(),this.$v.form.$pending||this.$v.form.$error||(this.sendSupportMessage({subject:"Contacts form",email:this.form.email,full_name:this.form.name,type:"general",message:this.form.textarea}).then((function(){t.form.name="",t.form.email="",t.form.textarea="",t.form.formSubmit=!0})),this.$v.$reset(),setTimeout((function(){t.form.formSubmit=!1}),1e4))}}),head:function(){return{title:this.$t("seo.contacts.title")}}},h=(n(1512),n(1)),component=Object(h.a)(f,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("section",{staticClass:"contacts_section"},[n("Breadcrumbs"),t._v(" "),n("h1",{staticClass:"contacts_title"},[t._v(t._s(t.$t("contacts.contacts_caption")))]),t._v(" "),n("div",{staticClass:"contacts_wrapper"},[n("div",{staticClass:"contacts_info"},[n("div",{staticClass:"contacts_infoItem"},[n("div",{staticClass:"contacts_infoItemTitle"},[t._v(t._s(t.$t("contacts.contacts_working_hours")))]),t._v(" "),n("div",{staticClass:"contacts_infoItemDesc"},[t._v(t._s(t.$t("contacts.contacts_working_hours_desr")))])])]),t._v(" "),n("div",{staticClass:"contacts_description"},[t._v("\n      "+t._s(t.$t("contacts.contacts_descr"))+"\n      ")]),t._v(" "),t._m(0)])],1)}),[function(){var t=this.$createElement,e=this._self._c||t;return e("div",{staticClass:"contacts_form"},[e("div",{attrs:{id:"hubspotForm"}})])}],!1,null,null,null);e.default=component.exports;installComponents(component,{Breadcrumbs:n(959).default})},958:function(t,e,n){var content=n(973);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[t.i,content,""]]),content.locals&&(t.exports=content.locals);(0,n(8).default)("3e639928",content,!0,{sourceMap:!1})},959:function(t,e,n){"use strict";n.r(e);n(12),n(9),n(13),n(18),n(10),n(19);var r=n(3);n(150),n(29),n(68),n(49),n(35),n(92),n(30),n(33),n(39),n(67),n(40);function o(object,t){var e=Object.keys(object);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(object);t&&(n=n.filter((function(t){return Object.getOwnPropertyDescriptor(object,t).enumerable}))),e.push.apply(e,n)}return e}var c=n(971),l={name:"Breadcrumbs",props:{title:{type:String,default:null}},computed:{crumbs:function(){var t=this,e=this.$route.path,n=e.startsWith("/")?e.substring(1).split("/"):e.split("/"),l=[],path="";return n.map((function(param){path="".concat(path,"/").concat(param);var e=t.$router.match(path);null===e.name||e.path.includes("page-")||t.$i18n.locales.map((function(t){return"/"+t.code})).includes(e.path)||l.push(function(t){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?o(Object(source),!0).forEach((function(e){Object(r.a)(t,e,source[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(source)):o(Object(source)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(source,e))}))}return t}({title:["/coin","-to-"].some((function(t){return e.path.includes(t)}))?c(param.replace(/-/g," ")):t.$t("breadcrumbs.".concat([e.path.split("/").slice(-1)[0]]))},e))})),l}},methods:{languageCodes:function(){return this.$i18n.locales.map((function(t){return"/"+t.code}))},translateandler:function(path){return path.includes("to")?path.replace("to","".concat(this.$t("breadcrumbs.to"))):path}}},m=(n(972),n(1)),component=Object(m.a)(l,(function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("nav",{staticClass:"breadcrumbs",attrs:{itemscope:"",itemtype:"http://schema.org/BreadcrumbList"}},[n("span",{staticClass:"breadcrumbs_item",attrs:{itemprop:"itemListElement",itemscope:"",itemtype:"http://schema.org/ListItem"}},[n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:t.localePath("/")}},[t._v("LetsExchange")]),t._v(" "),n("meta",{attrs:{itemprop:"name",content:"LetsExchange"}}),t._v(" "),n("meta",{attrs:{itemprop:"position",content:"1"}})]),t._v(" "),t._l(t.crumbs,(function(e,r){return n("span",{key:r,staticClass:"breadcrumbs_item",attrs:{itemprop:"itemListElement",itemscope:"",itemtype:"http://schema.org/ListItem"}},[r==t.crumbs.length-1?n("a",{staticClass:"breadcrumbs_link",attrs:{href:t.$route.fullPath,itemprop:"item"}},[t._v("\n      "+t._s(t.$route.fullPath===e.path&&null!==t.title?t.translateandler(t.title):t.translateandler(e.title))+"\n    ")]):"Coin"===e.title&&0===r?n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:t.localePath("/exchange-rates")}},[t._v("\n      "+t._s(t.$t("breadcrumbs.exchange-rates"))+"\n    ")]):"Exchange"===e.title&&0===r?n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:t.localePath("/exchange-pairs")}},[t._v("\n      "+t._s(t.$t("breadcrumbs.exchange-pairs"))+"\n    ")]):n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:e.path.includes("exchange")?t.localePath("/exchange-pairs"):e.path}},[t._v("\n      "+t._s(t.$route.fullPath===e.path&&null!==t.title?t.title:e.title)+"\n    ")]),t._v(" "),r==t.crumbs.length-1?n("meta",{attrs:{itemprop:"name",content:t.$route.fullPath===e.path&&null!==t.title?t.title:e.title}}):"Coin"===e.title&&0===r?n("meta",{attrs:{itemprop:"name",content:"Exchange Rates"}}):"Exchange"===e.title&&0===r?n("meta",{attrs:{itemprop:"name",content:"Exchange Pairs"}}):n("meta",{attrs:{itemprop:"name",content:t.$route.fullPath===e.path&&null!==t.title?t.title:e.title}}),t._v(" "),n("meta",{attrs:{itemprop:"position",content:r+2}})])}))],2)}),[],!1,null,"a768d0ce",null);e.default=component.exports;installComponents(component,{Nav:n(69).default})},971:function(t,e,n){"use strict";t.exports=function(t,e){const n=e||{};if(!t)return"";const o=n.stopwords||r,c=n.keepSpaces,l=/(\s+|[-‑–—])/;return t.split(l).map(((t,e,n)=>t.match(/\s+/)?c?t:" ":t.match(l)?t:0!==e&&e!==n.length-1&&o.includes(t.toLowerCase())?t.toLowerCase():function(t){return t.charAt(0).toUpperCase()+t.slice(1)}(t))).join("")};const r="a an and at but by for in nor of on or so the to up yet".split(" ")},972:function(t,e,n){"use strict";n(958)},973:function(t,e,n){var r=n(7)(!1);r.push([t.i,'.breadcrumbs[data-v-a768d0ce]{width:100%;list-style-type:none;display:flex;padding:0;margin:0 0 16px}.breadcrumbs_item[data-v-a768d0ce]{display:flex;align-items:center;margin:0 5px 0 0}.breadcrumbs_item[data-v-a768d0ce]:after{content:"/";margin:0 0 0 5px;color:hsla(0,0%,100%,.6)}.breadcrumbs_item[data-v-a768d0ce]:last-child{margin:0}.breadcrumbs_item[data-v-a768d0ce]:last-child:after{display:none}.breadcrumbs_link[data-v-a768d0ce]{color:hsla(0,0%,100%,.6);font-size:14px;line-height:140%}',""]),t.exports=r}}]);
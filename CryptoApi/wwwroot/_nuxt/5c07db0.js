(window.webpackJsonp=window.webpackJsonp||[]).push([[13,19,34,47],{1078:function(e,t,n){e.exports=n.p+"img/tableSwapGray.081cdec.svg"},1091:function(e,t,n){var content=n(1143);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(8).default)("f8d3122e",content,!0,{sourceMap:!1})},1102:function(e,t,n){"use strict";n.r(t);n(148);var o={name:"Paginator",props:{numberOfPages:{type:Number,default:0,required:!0},linkGen:{type:Function,default:function(){return null},required:!0},paginationHandler:{type:Function,default:function(){return null},required:!0},paginationPageNumber:{type:String,default:""},theme:{type:String,default:"dark"}},computed:{paginationPageNumberHandler:function(){return this.paginationPageNumber}}},r=(n(1142),n(1)),component=Object(r.a)(o,(function(){var e=this,t=e.$createElement,n=e._self._c||t;return e.numberOfPages?n("div",{class:"dark"===e.theme?"paginationWrapper dark":"paginationWrapper"},[n("b-pagination-nav",{attrs:{"link-gen":e.linkGen,"next-class":"next-pagination-btn","prev-class":"prev-pagination-btn","number-of-pages":e.numberOfPages,"use-router":""},on:{change:e.paginationHandler},model:{value:e.paginationPageNumberHandler,callback:function(t){e.paginationPageNumberHandler=t},expression:"paginationPageNumberHandler"}})],1):e._e()}),[],!1,null,null,null);t.default=component.exports},1141:function(e,t,n){var content=n(1257);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(8).default)("6e387bc2",content,!0,{sourceMap:!1})},1142:function(e,t,n){"use strict";n(1091)},1143:function(e,t,n){var o=n(7)(!1);o.push([e.i,".paginationWrapper{width:100%;margin:32px 0 0}.paginationWrapper a{color:#fff}.paginationWrapper .pagination{padding:0;display:flex;align-items:center;justify-content:center}.paginationWrapper .pagination li{margin:0 6px;width:56px;height:46px;border:1px solid #fff;border-radius:11px;background:rgba(183,243,72,.1);font-weight:500;font-size:16px;line-height:170%;color:#fff;outline:none;display:flex;align-items:center;justify-content:center}.paginationWrapper .pagination li:hover{background:#b7f348;border:1px solid #b7f348}.paginationWrapper .pagination li:hover .page-link{color:#000}.paginationWrapper .pagination li a{width:100%;height:100%;display:flex;align-items:center;outline:none;justify-content:center}.paginationWrapper .pagination li.active{background:#b7f348;border:1px solid #b7f348}.paginationWrapper .pagination li.active a{color:#000}.paginationWrapper .pagination li.disabled{display:none}.paginationWrapper.dark .pagination li{background:#1b143a;border:none}.paginationWrapper.dark .pagination li:hover{background:#b7f348;border:1px solid #b7f348}.paginationWrapper.dark .pagination li:hover .page-link{color:#000}.paginationWrapper.dark .pagination li.active{background:#b7f348;border:1px solid #b7f348}.paginationWrapper.dark .pagination li.active a{color:#000}",""]),e.exports=o},1256:function(e,t,n){"use strict";n(1141)},1257:function(e,t,n){var o=n(7)(!1);o.push([e.i,'.change{display:flex;align-items:center;padding:8px 10px;font-size:16px;font-weight:700;line-height:19px;letter-spacing:-.04em;border-radius:8px;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}.change-up{background:rgba(34,185,94,.1);color:#22b95e}.change-down{background:rgba(216,57,57,.1);color:#f13c3c}.coinName{margin:0 0 0 15px}.coinCode{display:flex;align-items:center}.coinCode:before{content:"(";margin-right:2px;display:none}@media only screen and (min-width:1024px){.coinCode:before{display:block}}.coinCode:after{content:")";margin-left:2px;display:none}@media only screen and (min-width:1024px){.coinCode:after{display:block}}.coinCodeUnscoped:after,.coinCodeUnscoped:before{content:"";display:none}.coinFullName{margin:0 8px 0 0;display:none}@media only screen and (min-width:1024px){.coinFullName{display:block}}.price-code{color:hsla(0,0%,100%,.6)}.coin-icon{max-width:32px;width:32px;height:32px;flex:1 0 auto;border-radius:50%;margin:0 18px 0 0}.table{width:100%;position:relative;border-radius:24px;overflow:hidden}.table thead .md-table-head{background:#171131;height:70px;padding:0!important;border-bottom:1px solid hsla(0,0%,100%,.16)}.table thead .md-table-head-container{padding:0 0 17px;height:100%;display:flex;align-items:flex-end}.table thead .md-table-head-label{color:#fff;font-weight:500;font-size:14px;line-height:19px;display:flex;position:relative;height:30px;align-items:center}.table thead .md-table-head-label i{display:none}@media only screen and (max-width:480px){.table thead .md-table-head-label{padding:6px 8px}}@media only screen and (min-width:1024px){.table thead .md-table-head-label{font-size:16px}}.table tbody .md-table-row{cursor:pointer}.table tbody .md-table-row.table-withdrawal-disabled{cursor:default}.table tbody .md-table-row .md-table-cell{background:#171131;border-top:none;height:80px}.table tbody .md-table-row .md-table-cell-container{color:#fff;font-weight:500;font-size:12px;line-height:19px;display:flex;align-items:center;padding:6px 8px}@media only screen and (min-width:480px){.table tbody .md-table-row .md-table-cell-container{padding:6px 32px 6px 24px}}@media only screen and (min-width:1024px){.table tbody .md-table-row .md-table-cell-container{font-size:16px}}.table tbody .md-table-row .md-table-cell-container a{pointer-events:none;display:flex;align-items:center;color:inherit;transition:color 1s ease-out}.table tbody .md-table-row:first-child .md-table-cell{border-top:1px solid #1b143a}.table tbody .md-table-row:nth-child(odd) .md-table-cell{background:#1f1743}.table tbody .md-table-row:hover .md-table-cell{background:#0f0b1f!important}.table tbody .md-table-row:hover .md-table-cell-container a{text-decoration:underline;color:hsla(0,0%,100%,.6)}.md-table-head.md-sortable .md-table-head-label:before{transform:rotate(45deg);-webkit-transform:rotate(45deg);bottom:11px}.md-table-head.md-sortable .md-table-head-label:after,.md-table-head.md-sortable .md-table-head-label:before{border:solid #fff;border-width:0 1px 1px 0;display:inline-block;padding:2px;position:absolute;opacity:.5;content:"";right:14px;transition:all .3s ease}.md-table-head.md-sortable .md-table-head-label:after{transform:rotate(-135deg);-webkit-transform:rotate(-135deg);top:11px}.md-table-head.md-sorted .md-table-head-label:after{opacity:1}.md-table-head.md-sorted.md-sorted-desc .md-table-head-label:after{opacity:.5}.md-table-head.md-sorted.md-sorted-desc .md-table-head-label:before{opacity:1}.table-topExchange{margin:30px 0 0}.table-topExchange .price-code{margin-left:10px}.table-topExchange tbody .md-table-row .md-table-cell-container a{pointer-events:all!important}.table-topExchange .tableTopExchangeBtn{color:#fff;font-size:0;line-height:19px}@media only screen and (min-width:868px){.table-topExchange .tableTopExchangeBtn{padding:15px 38px;font-size:16px;border:1px solid #b7f348;border-radius:8px;background:rgba(183,243,72,.1)}}.table-topExchange .tableTopExchangeBtnDots{display:flex;flex-direction:column}.table-topExchange .tableTopExchangeBtnDots span{width:5px;height:5px;border-radius:50%;background:hsla(0,0%,100%,.1);margin-bottom:4px}.table-topExchange .tableTopExchangeBtnDots span:last-child{margin-bottom:0}@media only screen and (min-width:868px){.table-topExchange .tableTopExchangeBtnDots{display:none}}.table-topExchange .toIcon{height:16px;width:100%;display:flex;align-items:center;justify-content:center;border-radius:50%}',""]),e.exports=o},1352:function(e,t,n){"use strict";n.r(t);n(12),n(9),n(13),n(18),n(10),n(19);var o=n(3),r=(n(35),n(977)),l=n(147),c=n(4),d=n(980),m=n(981);function f(object,e){var t=Object.keys(object);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(object);e&&(n=n.filter((function(e){return Object.getOwnPropertyDescriptor(object,e).enumerable}))),t.push.apply(t,n)}return t}var h={name:"FullCoinsTableExchange",components:{CryptoCoin:l.default},props:{pairs:{type:Array,default:function(){return[]}}},data:function(){return{getCoinByCode:r.a,modifyChange:d.a,modifyChangeClass:m.a}},computed:function(e){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?f(Object(source),!0).forEach((function(t){Object(o.a)(e,t,source[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(source)):f(Object(source)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(source,t))}))}return e}({},Object(c.c)("app",["isMobile"])),methods:{toCoinPage:function(e,t){this.$router.push({path:this.localePath("/exchange/".concat(e.toLowerCase(),"-to-").concat(t.toLowerCase()))})}}},x=(n(1256),n(1)),component=Object(x.a)(h,(function(){var e=this,t=e.$createElement,o=e._self._c||t;return o("div",{staticClass:"table table-topExchange"},[o("md-table",{attrs:{"md-card":""},scopedSlots:e._u([{key:"md-table-row",fn:function(t){var r=t.item;return o("md-table-row",{on:{click:function(t){return e.toCoinPage(r.coin_from,r.coin_to)}}},[o("md-table-cell",{attrs:{"md-label":e.$t("exchange_pairs.coin")}},[o("nuxt-link",{attrs:{to:e.localePath("/coin/"+r.coin_from.toLowerCase())}},[o("div",{staticClass:"coin-icon coin-iconCoinPage"},[o("CryptoCoin",{attrs:{size:"32",currency:r.coin_from}})],1),e._v(" "),o("div",{staticClass:"coinCode coinCodeUnscoped"},[e._v(e._s(r.coin_from))]),e._v(" "),o("div",{staticClass:"coinName"},[e._v(e._s(r.coin_name_from))])])],1),e._v(" "),o("md-table-cell",{attrs:{"md-label":e.$t("exchange_pairs.change_24h"),"md-sort-by":"percent_change_24h"}},[o("div",{class:"change "+e.modifyChangeClass(r.change_from)},[e._v("\n          "+e._s(e.modifyChange(r.change_from))+"\n        ")])]),e._v(" "),o("md-table-cell",{attrs:{"md-label":e.$t("exchange_pairs.to")}},[o("div",{staticClass:"toIcon"},[o("img",{attrs:{src:n(1078),alt:"table-swap-arrows"}})])]),e._v(" "),o("md-table-cell",{attrs:{"md-label":e.$t("exchange_pairs.coin")}},[o("nuxt-link",{attrs:{to:e.localePath("/coin/"+r.coin_to.toLowerCase())}},[o("div",{staticClass:"coin-icon coin-iconCoinPage"},[o("CryptoCoin",{attrs:{size:"32",currency:r.coin_to}})],1),e._v(" "),o("div",{staticClass:"coinCode coinCodeUnscoped"},[e._v(e._s(r.coin_to))]),e._v(" "),o("div",{staticClass:"coinName"},[e._v(e._s(r.coin_name_to))])])],1),e._v(" "),o("md-table-cell",{attrs:{"md-label":e.$t("exchange_pairs.change_24h"),"md-sort-by":"percent_change_24h"}},[o("div",{class:"change "+e.modifyChangeClass(r.change_to)},[e._v("\n          "+e._s(e.modifyChange(r.change_to))+"\n        ")])]),e._v(" "),o("md-table-cell",[o("nuxt-link",{staticClass:"tableTopExchangeBtn",attrs:{to:e.localePath("/exchange/"+r.coin_from.toLowerCase()+"-to-"+r.coin_to.toLowerCase())}},[e._v("\n          "+e._s(e.$t("exchange_pairs.exchange"))+"\n          "),o("div",{staticClass:"tableTopExchangeBtnDots"},[o("span"),o("span"),o("span")])])],1)],1)}}]),model:{value:e.pairs,callback:function(t){e.pairs=t},expression:"pairs"}})],1)}),[],!1,null,null,null);t.default=component.exports;installComponents(component,{CryptoCoin:n(147).default})},1394:function(e,t,n){"use strict";n.d(t,"a",(function(){return o}));n(35);var o=function(e,t,n){return n(1===e?t:"".concat(t,"page-").concat(e))}},958:function(e,t,n){var content=n(973);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,n(8).default)("3e639928",content,!0,{sourceMap:!1})},959:function(e,t,n){"use strict";n.r(t);n(12),n(9),n(13),n(18),n(10),n(19);var o=n(3);n(150),n(29),n(68),n(49),n(35),n(92),n(30),n(33),n(39),n(67),n(40);function r(object,e){var t=Object.keys(object);if(Object.getOwnPropertySymbols){var n=Object.getOwnPropertySymbols(object);e&&(n=n.filter((function(e){return Object.getOwnPropertyDescriptor(object,e).enumerable}))),t.push.apply(t,n)}return t}var l=n(971),c={name:"Breadcrumbs",props:{title:{type:String,default:null}},computed:{crumbs:function(){var e=this,t=this.$route.path,n=t.startsWith("/")?t.substring(1).split("/"):t.split("/"),c=[],path="";return n.map((function(param){path="".concat(path,"/").concat(param);var t=e.$router.match(path);null===t.name||t.path.includes("page-")||e.$i18n.locales.map((function(e){return"/"+e.code})).includes(t.path)||c.push(function(e){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?r(Object(source),!0).forEach((function(t){Object(o.a)(e,t,source[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(source)):r(Object(source)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(source,t))}))}return e}({title:["/coin","-to-"].some((function(e){return t.path.includes(e)}))?l(param.replace(/-/g," ")):e.$t("breadcrumbs.".concat([t.path.split("/").slice(-1)[0]]))},t))})),c}},methods:{languageCodes:function(){return this.$i18n.locales.map((function(e){return"/"+e.code}))},translateandler:function(path){return path.includes("to")?path.replace("to","".concat(this.$t("breadcrumbs.to"))):path}}},d=(n(972),n(1)),component=Object(d.a)(c,(function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("nav",{staticClass:"breadcrumbs",attrs:{itemscope:"",itemtype:"http://schema.org/BreadcrumbList"}},[n("span",{staticClass:"breadcrumbs_item",attrs:{itemprop:"itemListElement",itemscope:"",itemtype:"http://schema.org/ListItem"}},[n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:e.localePath("/")}},[e._v("LetsExchange")]),e._v(" "),n("meta",{attrs:{itemprop:"name",content:"LetsExchange"}}),e._v(" "),n("meta",{attrs:{itemprop:"position",content:"1"}})]),e._v(" "),e._l(e.crumbs,(function(t,o){return n("span",{key:o,staticClass:"breadcrumbs_item",attrs:{itemprop:"itemListElement",itemscope:"",itemtype:"http://schema.org/ListItem"}},[o==e.crumbs.length-1?n("a",{staticClass:"breadcrumbs_link",attrs:{href:e.$route.fullPath,itemprop:"item"}},[e._v("\n      "+e._s(e.$route.fullPath===t.path&&null!==e.title?e.translateandler(e.title):e.translateandler(t.title))+"\n    ")]):"Coin"===t.title&&0===o?n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:e.localePath("/exchange-rates")}},[e._v("\n      "+e._s(e.$t("breadcrumbs.exchange-rates"))+"\n    ")]):"Exchange"===t.title&&0===o?n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:e.localePath("/exchange-pairs")}},[e._v("\n      "+e._s(e.$t("breadcrumbs.exchange-pairs"))+"\n    ")]):n("a",{staticClass:"breadcrumbs_link",attrs:{itemprop:"item",href:t.path.includes("exchange")?e.localePath("/exchange-pairs"):t.path}},[e._v("\n      "+e._s(e.$route.fullPath===t.path&&null!==e.title?e.title:t.title)+"\n    ")]),e._v(" "),o==e.crumbs.length-1?n("meta",{attrs:{itemprop:"name",content:e.$route.fullPath===t.path&&null!==e.title?e.title:t.title}}):"Coin"===t.title&&0===o?n("meta",{attrs:{itemprop:"name",content:"Exchange Rates"}}):"Exchange"===t.title&&0===o?n("meta",{attrs:{itemprop:"name",content:"Exchange Pairs"}}):n("meta",{attrs:{itemprop:"name",content:e.$route.fullPath===t.path&&null!==e.title?e.title:t.title}}),e._v(" "),n("meta",{attrs:{itemprop:"position",content:o+2}})])}))],2)}),[],!1,null,"a768d0ce",null);t.default=component.exports;installComponents(component,{Nav:n(69).default})},971:function(e,t,n){"use strict";e.exports=function(e,t){const n=t||{};if(!e)return"";const r=n.stopwords||o,l=n.keepSpaces,c=/(\s+|[-‑–—])/;return e.split(c).map(((e,t,n)=>e.match(/\s+/)?l?e:" ":e.match(c)?e:0!==t&&t!==n.length-1&&r.includes(e.toLowerCase())?e.toLowerCase():function(e){return e.charAt(0).toUpperCase()+e.slice(1)}(e))).join("")};const o="a an and at but by for in nor of on or so the to up yet".split(" ")},972:function(e,t,n){"use strict";n(958)},973:function(e,t,n){var o=n(7)(!1);o.push([e.i,'.breadcrumbs[data-v-a768d0ce]{width:100%;list-style-type:none;display:flex;padding:0;margin:0 0 16px}.breadcrumbs_item[data-v-a768d0ce]{display:flex;align-items:center;margin:0 5px 0 0}.breadcrumbs_item[data-v-a768d0ce]:after{content:"/";margin:0 0 0 5px;color:hsla(0,0%,100%,.6)}.breadcrumbs_item[data-v-a768d0ce]:last-child{margin:0}.breadcrumbs_item[data-v-a768d0ce]:last-child:after{display:none}.breadcrumbs_link[data-v-a768d0ce]{color:hsla(0,0%,100%,.6);font-size:14px;line-height:140%}',""]),e.exports=o},977:function(e,t,n){"use strict";n.d(t,"a",(function(){return o}));n(61);var o=function(e,code){return code&&"string"==typeof code&&Array.isArray(e)&&e.length?e.find((function(e){return e.code.toLowerCase()===code.toLowerCase()})):null}},980:function(e,t,n){"use strict";n(982),n(148);t.a=function(e){if(e){var t=Number(e).toFixed(2);return t>0?"+".concat(t,"%"):"".concat(t,"%")}return"-"}},981:function(e,t,n){"use strict";n(148);t.a=function(e){return!!e&&(Number(e)>0?"change-up":"change-down")}},982:function(e,t,n){"use strict";var o=n(5),r=n(80),l=n(983),c=n(380),d=n(16),m=1..toFixed,f=Math.floor,h=function(e,t,n){return 0===t?n:t%2==1?h(e,t-1,n*e):h(e*e,t/2,n)},x=function(data,e,t){for(var n=-1,o=t;++n<6;)o+=e*data[n],data[n]=o%1e7,o=f(o/1e7)},y=function(data,e){for(var t=6,n=0;--t>=0;)n+=data[t],data[t]=f(n/e),n=n%e*1e7},v=function(data){for(var e=6,s="";--e>=0;)if(""!==s||0===e||0!==data[e]){var t=String(data[e]);s=""===s?t:s+c.call("0",7-t.length)+t}return s};o({target:"Number",proto:!0,forced:m&&("0.000"!==8e-5.toFixed(3)||"1"!==.9.toFixed(0)||"1.25"!==1.255.toFixed(2)||"1000000000000000128"!==(0xde0b6b3a7640080).toFixed(0))||!d((function(){m.call({})}))},{toFixed:function(e){var t,n,o,d,m=l(this),f=r(e),data=[0,0,0,0,0,0],_="",w="0";if(f<0||f>20)throw RangeError("Incorrect fraction digits");if(m!=m)return"NaN";if(m<=-1e21||m>=1e21)return String(m);if(m<0&&(_="-",m=-m),m>1e-21)if(n=(t=function(e){for(var t=0,n=e;n>=4096;)t+=12,n/=4096;for(;n>=2;)t+=1,n/=2;return t}(m*h(2,69,1))-69)<0?m*h(2,-t,1):m/h(2,t,1),n*=4503599627370496,(t=52-t)>0){for(x(data,0,n),o=f;o>=7;)x(data,1e7,0),o-=7;for(x(data,h(10,o,1),0),o=t-1;o>=23;)y(data,1<<23),o-=23;y(data,1<<o),x(data,1,1),y(data,2),w=v(data)}else x(data,0,n),x(data,1<<-t,0),w=v(data)+c.call("0",f);return w=f>0?_+((d=w.length)<=f?"0."+c.call("0",f-d)+w:w.slice(0,d-f)+"."+w.slice(d-f)):_+w}})},983:function(e,t){var n=1..valueOf;e.exports=function(e){return n.call(e)}}}]);
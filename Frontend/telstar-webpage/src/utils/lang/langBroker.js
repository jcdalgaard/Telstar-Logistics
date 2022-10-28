import langEng from '@/utils/lang/english.json'
import langFr from '@/utils/lang/french.json'
import Vue from 'vue'

const lang = Vue.observable({ current: langEng })
export default lang

export const langEnglish = langEng
export const langFrench = langFr
